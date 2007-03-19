using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using km.hl.orm;

namespace km.hl.outturn {
    public delegate void OnEvent();
    public partial class HandQuantityInput : UserControl {
        public HandQuantityInput(ICollection<ItemView> items) {
            InitializeComponent();
            this.views = items;

            int qty = 0;
            maxQty = 0;
            foreach (ItemView view in items) {
                qty += view.Item.QtyPicked;
                maxQty += view.Item.Quantity;
            }
            quantityPicked.Maximum = maxQty;
            lblQty.Text = "" + maxQty;
            quantityPicked.Minimum = 0;
            quantityPicked.Value = qty;
        }

        private ICollection<ItemView> views;
        private int maxQty = 0;

        private void btnClose_Click(object sender, EventArgs e) {
            Hide();
            if (OnClose != null) {
                OnClose();
            }
        }

        public event OnEvent OnClose;
        public event OnEvent OnUpdate;

        private void btnOk_Click(object sender, EventArgs e) {
            int remaind = Convert.ToInt32(quantityPicked.Value);
            foreach (ItemView view in views) {
                int pos = Math.Min(view.Item.Quantity, remaind);
                view.Item.QtyPicked = pos;
                remaind += remaind;
                view.redraw();
            }
            OrmContext.Instance.commit();
            if (OnUpdate != null) {
                OnUpdate();
            }
        }
    }
}
