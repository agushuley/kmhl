using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using km.hard.scan;
using km.hl.orm;

namespace km.hl.receipts {
    public partial class OrderItemsForm : AlertForm {
        private class MoveItemsDescComparer : IComparer<orm.OrderItem> {
            int IComparer<orm.OrderItem>.Compare(orm.OrderItem x, orm.OrderItem y) {
                return x.Description.CompareTo(y.Description);
            }
        }

        orm.Order order = null;
        public OrderItemsForm(orm.Order order) {
            InitializeComponent();

            this.order = order;

            orm.OrderItem[] items = new orm.OrderItem[order.Items.Count];
            order.Items.CopyTo(items, 0);
            Array.Sort(items, new MoveItemsDescComparer());
            itemsViews.Controls.Clear();

            itemsViews.AutoScrollPosition = new Point(0, 0);
            int top = 0;
            foreach (orm.OrderItem item in items) {
                ItemView itemView = new ItemView(item);
                itemsViews.Controls.Add(itemView);
                itemView.Click += new EventHandler(itemView_Click);
                itemView.Top = top;
                top += itemView.Height + 1;
            }
        }

        void itemView_Click(object sender, EventArgs e) {
            ItemView mainView = (ItemView)sender;
            int itemCode = mainView.Item.InventoryItemId;

            processSelected(selectByItemCode(itemCode));
        }

        private void ItemsForm_Load(object sender, EventArgs e) {
            redraw();

            Scanner s = Program.getScanner();
            s.Attach(this);

            s.Scanned += new OnScanned(s_Scanned);
        }

        void s_Scanned(string code) {
            this.code.Text = code;
            scanned();
        }
        
        private void scanned() {
            String scanedCode = code.Text;
            if (String.IsNullOrEmpty(scanedCode)) {
                alert("Пустой код");
                Program.playMinor();
                return;
            }

            int itemCode = 0;
            foreach (ItemView itemView in itemsViews.Controls) {
                orm.OrderItem item = itemView.Item;
                if (item.IsRightCode(scanedCode)) {
                    itemCode = item.InventoryItemId;
                    break;
                }
            }

            if (itemCode == 0) {
                Program.playMajor();
                AssignItemForm form = new AssignItemForm(order, scanedCode);
                if (form.ShowDialog() == DialogResult.OK) {
                    itemCode = form.SelectedItem.InventoryItemId;
                }
                else {
                    return;
                }
            }

            processSelected(selectByItemCode(itemCode));
        }

        private void processSelected(ICollection<ItemView> selected) {
            SerialsForm serials = new SerialsForm(selected);
            DialogResult result = serials.ShowDialog();
            if (result != DialogResult.Cancel) {
                bool noSerialNeed = false;
                int qty = 0;
                foreach (ItemView itemView in selected) {
                    itemView.redraw();
                    qty += itemView.Item.Quantity;
                    noSerialNeed = noSerialNeed || itemView.Item.NoSerials;
                }
                if (qty > MAX_ITEMS_WOSCAN && noSerialNeed) {
                    createHandQtyInput(selected);
                }
            }

            Iesi.Collections.ISet orders = new Iesi.Collections.HashedSet();
            foreach (ItemView item in selected) {
                orders.Add(item.Item.Order);
            }

            checkFinal();
        }

        private void checkFinal() {
            bool completed = true;
            foreach (orm.OrderItem item in order.Items) {
                if (item.QuantityChecked < item.Quantity) {
                    completed = false;
                    break;
                }
            }
            if (completed) {
                order.IsComplete = completed;
                OrmContext.Instance.commit();
                Program.playMinor();
            }
            redraw();
        }

        private const int MAX_ITEMS_WOSCAN = 20;

        private ICollection<ItemView> selectByItemCode(int itemCode) {
            ICollection<ItemView> selected = new List<ItemView>();
            itemsViews.AutoScrollPosition = new Point(0, 0);
            int top = 0;
            foreach (ItemView itemView in itemsViews.Controls) {
                if (itemView.Item.InventoryItemId == itemCode) {
                    selected.Add(itemView);
                    itemView.Visible = true;
                    itemView.Top = top;
                    top += itemView.Height;
                }
                else {
                    itemView.Visible = false;
                }
            }
            hideAlert();
            return selected;
        }

        #region Hand input
        HandQuantityInput handInput = null;
        internal void createHandQtyInput(ICollection<ItemView> items) {
            if (handInput != null) {
                closeHandQtyInput();
            }
            handInput = new HandQuantityInput(items);
            handInput.OnClose += new OnEvent(input_OnClose);
            handInput.OnUpdate += new OnEvent(input_OnUpdate);
            this.Controls.Add(handInput);
            handInput.Visible = true;
            handInput.Top = itemsViews.Top;
            handInput.Left = itemsViews.Left;
            itemsViews.Top += handInput.Height;
            itemsViews.Height -= handInput.Height;
        }

        public void closeHandQtyInput() {
            if (handInput != null) {
                handInput.Hide();
                this.Controls.Remove(handInput);
                itemsViews.Top -= handInput.Height;
                itemsViews.Height += handInput.Height;
                handInput = null;
            }
        }
        #endregion

        void input_OnClose() {
            closeHandQtyInput();
        }

        void input_OnUpdate() {
            foreach (ItemView itemView in itemsViews.Controls) {
                if (itemView.Visible) {
                    itemView.redraw();
                }
            }
            checkFinal();
            input_OnClose();
        }

        private void btnScanned_Click(object sender, EventArgs e) {
            scanned();
        }

        private void btnClear_Click(object sender, EventArgs e) {
            this.code.Text = "";
            itemsViews.AutoScrollPosition = new Point(0, 0);
            int top = 0;
            foreach (ItemView itemView in itemsViews.Controls) {
                itemView.Visible = true;
                itemView.Top = top;
                top += itemView.Height + 1;
                itemView.redraw();
            }
            hideAlert();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void status_Click(object sender, EventArgs e) {
            OrderStatusForm status = new OrderStatusForm();
            status.Status = order.IsComplete;
            if (status.ShowDialog() == DialogResult.OK) {
                order.IsComplete = status.Status;
                km.hl.orm.OrmContext.Instance.commit();
                redraw();
            }
        }

        public void redraw() {
            status.Image = order.IsComplete ? Resources.greenBall : Resources.redBall;
        }
    }
}