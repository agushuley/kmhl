using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace km.hl.receipts {
    public partial class OrdersForm : Form {
        public OrdersForm() {
            InitializeComponent();
        }

        private class OrdersNnumbersComparasion : IComparer<orm.Order> {
            public int Compare(km.hl.receipts.orm.Order x, km.hl.receipts.orm.Order y) {
                return x.Number.CompareTo(y.Number);
            }
        }
        private void OrdersForm_Load(object sender, EventArgs e) {
            ICollection<orm.Order> orders = new List<orm.Order>();
            foreach (orm.Order order in km.hl.orm.OrmContext.Instance.getMapper(typeof(orm.Order)).getAll()) {
                orders.Add(order);
            }            
            orm.Order[] ordersa = new orm.Order[orders.Count];
            orders.CopyTo(ordersa, 0);
            Array.Sort<orm.Order>(ordersa, new OrdersNnumbersComparasion());

            documentsPanel.Controls.Clear();
            documentsPanel.AutoScrollPosition = new Point(0, 0);
            int top = 0;
            for (int i = 0; i < ordersa.Length; i++) {
                OrderView item = new OrderView(ordersa[i]);
                item.Top = top;
                documentsPanel.Controls.Add(item);
                top += item.Height + 1;
            }
        }

        private void btnClose_Click(object sender, EventArgs e) {
            Close();
        }
    }
}