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
        public HandQuantityInput(ICollection<MoveOrderItem> items) {
            InitializeComponent();
            this.items = items;

            int qty = 0;
            maxQty = 0;
            foreach (MoveOrderItem item in items) {
                qty += item.QtyPicked;
                maxQty += item.Quantity;
            }
            quantityPicked.Maximum = maxQty;
            lblQty.Text = "" + maxQty;
            quantityPicked.Minimum = 0;
            quantityPicked.Value = qty;
        }

        private ICollection<MoveOrderItem> items;
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
            foreach (MoveOrderItem item in items) {
                int pos = Math.Min(item.Quantity, remaind);
                item.QtyPicked = pos;
                remaind += remaind;
            }
            Context.Instance.commit();
            if (OnUpdate != null) {
                OnUpdate();
            }
        }
    }
}
