using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace km.hl.outturn {
    class BuyerSelect {
        public BuyerSelect(ICollection<orm.MoveOrder> orders) {
            this.orders = orders;
        }
        ICollection<orm.MoveOrder> orders;

        public void load(Panel container) {
            ICollection<orm.Buyer> buyersl = new List<orm.Buyer>();
            foreach (orm.MoveOrder order in orders) {
                if (!buyersl.Contains(order.Buyer)) {
                    buyersl.Add(order.Buyer);
                }
            }

            orm.Buyer[] buyers = new km.hl.orm.Buyer[buyersl.Count];
            buyersl.CopyTo(buyers, 0);
            Array.Sort<orm.Buyer>(buyers, new BuyersNameComparasion());

            container.Controls.Clear();
            for (int i = buyers.Length - 1; i >= 0; i--) {
                BuyerItem item = new BuyerItem(buyers[i], orders);
                item.Dock = DockStyle.Top;
                item.TabIndex = buyers.Length - 1;
                container.Controls.Add(item);
                if (i == 0) {
                    item.Focus();
                }
            }
        }

        private class BuyersNameComparasion : IComparer<orm.Buyer> {
            public int Compare(km.hl.orm.Buyer x, km.hl.orm.Buyer y) {
                return x.Description.CompareTo(y.Description);
            }
        }
    }
}
