using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using km.hard.scan;
using km.hl.orm;

namespace km.hl.outturn {
    public partial class ItemsForm : Form {
        private class MoveItemsDescComparer : IComparer<MoveOrderItem> {
            int IComparer<MoveOrderItem>.Compare(MoveOrderItem x, MoveOrderItem y) {
                return x.Description.CompareTo(y.Description);
            }
        }

        public ItemsForm(ICollection<orm.MoveOrderItem> itemsCol) {
            InitializeComponent();
           
            orm.MoveOrderItem[] items = new MoveOrderItem[itemsCol.Count];
            itemsCol.CopyTo(items, 0);
            Array.Sort(items, new MoveItemsDescComparer());
            itemsViews.Controls.Clear();
            int top = 0;
            foreach (orm.MoveOrderItem item in items) {
                ItemView itemView = new ItemView(item);
                itemsViews.Controls.Add(itemView);
                itemView.Click += new EventHandler(itemView_Click);
                itemView.Top = top;
                top += itemView.Height;
            }
        }

        void itemView_Click(object sender, EventArgs e) {
            ItemView mainView = (ItemView)sender;
            int itemCode = mainView.Item.InventoryId;
            selected.Clear();
            int top = 0;
            foreach (ItemView itemView in itemsViews.Controls) {
                if (itemView.Item.InventoryId == itemCode) {
                    selected.Add(itemView.Item);
                    itemView.Visible = true;
                    itemView.Top = top;
                    top += itemView.Height;
                }
                else {
                    itemView.Visible = false;
                }
            }

            SerialsForm serials = new SerialsForm(selected);
            DialogResult result = serials.ShowDialog();
            if (result != DialogResult.Cancel) {
                foreach (ItemView itemView in itemsViews.Controls) {
                    if (itemView.Visible) {
                        itemView.redraw();
                    }
                }
            }
        }

        ICollection<orm.MoveOrderItem> selected = new List<orm.MoveOrderItem>();

        private void ItemsForm_Load(object sender, EventArgs e) {
            Scanner s = Program.getScanner();
            s.Attach(this);

            s.Scanned += new OnScanned(s_Scanned);
        }

        void s_Scanned(string code) {
            this.code.Text = code;
            scanned();
        }

        private void scanned() {
            closeHandQtyInput();

            String code = this.code.Text;
            if (String.IsNullOrEmpty(code)) {
                Program.getBuzzer().Play(km.hard.BuzzerVolume.mid, 25, 100);
                return;
            }
            int itemCode = 0;
            foreach (ItemView itemView in itemsViews.Controls) {
                orm.MoveOrderItem item = itemView.Item;
                if (item.IsRightCode(code)) 
                {
                    itemCode = item.InventoryId;
                    break;
                }
            }
            if (itemCode == 0) {
                this.Text = "�� ������� �������";
                Program.playMinor();
                return;
            }
            selected.Clear();
            bool unpickedFound = false;
            bool noSerialNeed = false;
            int top = 0;
            foreach (ItemView itemView in itemsViews.Controls) {
                if (itemView.Item.InventoryId == itemCode) {
                    selected.Add(itemView.Item);
                    itemView.Visible = true;
                    itemView.Top = top;
                    top += itemView.Height;
                    if (itemView.Item.Quantity > itemView.Item.QtyPicked) {
                        unpickedFound = true;
                    }
                    if (itemView.Item.NoSerialNeed) {
                        noSerialNeed = true;
                    }
                }
                else {
                    itemView.Visible = false;
                }
            }

            if (!unpickedFound) {
                Program.playMinor();
                this.Text = "��� ���������� ������� ��������";
                return;
            }

            if (!noSerialNeed) {
                SerialsForm serials = new SerialsForm(selected);
                DialogResult result = serials.ShowDialog();
                if (result != DialogResult.Cancel) {
                    foreach (ItemView itemView in itemsViews.Controls) {
                        if (itemView.Visible) {
                            itemView.redraw();
                        }
                    }
                    noSerialNeed = false;
                    int qty = 0;
                    foreach (MoveOrderItem item in selected) {
                        qty += item.Quantity;
                        noSerialNeed = noSerialNeed || item.NoSerialNeed;
                    }
                    if (qty > MAX_ITEMS_WOSCAN && noSerialNeed) {
                        createHandQtyInput();
                    }
                }
            }
            else {
                foreach (MoveOrderItem item in selected) {
                    if (item.QtyPicked < item.Quantity) {
                        item.QtyPicked++;
                        break;
                    }
                }
                orm.Context.Instance.commit();
                Program.playMajor();
            }
        }

        private const int MAX_ITEMS_WOSCAN = 20;

        HandQuantityInput handInput = null;
        private void createHandQtyInput() {
            if (handInput != null) {
                closeHandQtyInput();
            }
            handInput = new HandQuantityInput(selected);
            handInput.OnClose += new OnEvent(input_OnClose);
            handInput.OnUpdate += new OnEvent(input_OnUpdate);
            this.Controls.Add(handInput);
            handInput.Visible = true;
            handInput.Top = itemsViews.Top;
            handInput.Left = itemsViews.Left;
            itemsViews.Top += handInput.Height + 2;
        }

        private void closeHandQtyInput() {
            if (handInput != null) {
                handInput.Hide();
                this.Controls.Remove(handInput);
                itemsViews.Top -= handInput.Height + 2;
                handInput = null;
            }
        }

        void input_OnClose() {
            closeHandQtyInput();
        }

        void input_OnUpdate() {
            foreach (ItemView itemView in itemsViews.Controls) {
                if (itemView.Visible) {
                    itemView.redraw();
                }
            }
            input_OnClose();
        }

        private void btnScanned_Click(object sender, EventArgs e) {
            scanned();
        }

        private void btnClear_Click(object sender, EventArgs e) {
            this.code.Text = "";
            int top = 0;
            foreach (ItemView itemView in itemsViews.Controls) {
                itemView.Visible = true;
                itemView.Top = top;
                top += itemView.Height;
            }
            selected.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}