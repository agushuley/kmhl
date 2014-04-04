using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using km.hl.orm;

namespace km.hl.receipts {
    public delegate void OnEvent();
    public partial class HandQuantityInput : UserControl {
        public HandQuantityInput(ICollection<ItemView> items) {
            InitializeComponent();
            this.views = items;

            int qty = 0;
            maxQty = 0;
            foreach (ItemView view in items) {
                qty += view.Item.QuantityChecked;
                maxQty += view.Item.Quantity;
            }
            lblQty.Text = "" + maxQty;
            quantityPicked.Text = qty.ToString();
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
            try {
                int remaind = Int32.Parse(quantityPicked.Text);
                if (remaind < 0 || remaind > maxQty) {
                    MessageBox.Show("К-во должно быть в границах между 0 и " + maxQty, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }
                foreach (ItemView view in views) {
                    int pos = Math.Min(view.Item.Quantity, remaind);
                    view.Item.QuantityChecked = pos;
                    remaind -= pos;
                    view.redraw();
                }
                OrmContext.Instance.commit();
                if (OnUpdate != null) {
                    OnUpdate();
                }
            } catch (FormatException) {
                MessageBox.Show("Ошибка формата номера", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
