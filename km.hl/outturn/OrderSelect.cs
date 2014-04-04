using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

using km.hl.outturn.orm;

namespace km.hl.outturn {
    class OrderSelect {
        public OrderSelect(ICollection<orm.MoveOrder> orders, ScanAlgorithm alghoritm) {
            this.orders = orders;
            this.alghoritm = alghoritm;
        }
        private ICollection<orm.MoveOrder> orders;
        private ScanAlgorithm alghoritm;

        public void load(Panel container) {
            orm.MoveOrder[] ordersa = new orm.MoveOrder[orders.Count];
            orders.CopyTo(ordersa, 0);
            Array.Sort<orm.MoveOrder>(ordersa, new OrdersNnumbersComparasion());

            container.Controls.Clear();
            container.AutoScrollPosition = new Point(0, 0);
            int top = 0;
            for (int i = 0; i < ordersa.Length; i++) {
                OrderItem item = new OrderItem(ordersa[i], alghoritm);
                item.Top = top;
                container.Controls.Add(item);
                top += item.Height + 1;
            }
        }

        private class OrdersNnumbersComparasion : IComparer<orm.MoveOrder> {
            public int Compare(MoveOrder x, MoveOrder y) {
                return x.Number.CompareTo(y.Number);
            }
        }
    }
}
