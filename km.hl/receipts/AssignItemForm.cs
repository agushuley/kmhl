using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace km.hl.receipts {
    public partial class AssignItemForm : AlertForm {
        public AssignItemForm(orm.Order order, String scanedCode) {
            InitializeComponent();

            this.tbCode.Text = scanedCode;
            this.order = order;
        }

        private orm.Order order;
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            int top = 0;
            {
                orm.OrderItem item = new km.hl.receipts.orm.OrderItem(new orm.OrderItemKey(0, 0), null, 0, null, "Новая позиция...");

                ItemView view = new ItemView(item);
                items.Controls.Add(view);
                view.Top = top;
                top += view.Height;
                view.Click += new EventHandler(newItemClick);
            }

            orm.OrderItem[] itemsArr = new orm.OrderItem[order.Items.Count];
            order.Items.CopyTo(itemsArr, 0);
            Array.Sort(itemsArr, new OrderItemsComparer());

            foreach (orm.OrderItem item in itemsArr) {
                ItemView view = new ItemView(item);
                items.Controls.Add(view);
                view.Top = top;
                top += view.Height;
                view.Click += new EventHandler(itemClick);
            }
        }

        private void itemClick(Object sender, EventArgs e) {
            if (tbCode.Text.IndexOf('/') != -1) {
                alert("Дополнительный код не может содержать символ слеша '/'");
                return;
            }
            
            ItemView v = (ItemView)sender;

            if (String.IsNullOrEmpty(v.Item.MfrCode)) {
                v.Item.MfrCode = tbCode.Text;
            }
            else {
                v.Item.MfrExtCodes.Add(tbCode.Text);
            }
            km.hl.orm.OrmContext.Instance.commit();
            this.selectedItem = v.Item;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void newItemClick(Object sender, EventArgs e) {
            NewItemForm newItemForm = new NewItemForm();
            newItemForm.Code = tbCode.Text;
            if (newItemForm.ShowDialog() != DialogResult.OK) {
                return;
            }
            int inventoryId = 0;
            foreach (orm.OrderItem item in order.Items) {
                if (item.InventoryItemId < 0) {
                    inventoryId = Math.Min(inventoryId, item.InventoryItemId);
                }
            }
            inventoryId = inventoryId - 1;

            g.orm.Mapper mapper = km.hl.orm.OrmContext.Instance.getMapper(typeof(orm.OrderItem));
            orm.OrderItem newItem = new km.hl.receipts.orm.OrderItem(
                (orm.OrderItemKey)mapper.createKey(),
                order, inventoryId, "" + inventoryId, newItemForm.ItemCaption);
            newItem.MfrCode = newItemForm.Code;
            order.Items.Add(newItem);
            mapper.add(newItem);
            km.hl.orm.OrmContext.Instance.commit();
            this.selectedItem = newItem;
            this.isNew = true;
            DialogResult = DialogResult.OK;
            Close();
        }

        private orm.OrderItem selectedItem;
        public orm.OrderItem SelectedItem { get { return selectedItem; } }

        private class OrderItemsComparer : IComparer<orm.OrderItem> {
            public int Compare(orm.OrderItem x, orm.OrderItem y) {
                return x.Description.CompareTo(y.Description);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private bool isNew = false;
        public bool IsNew { get { return isNew; } }
    }
}