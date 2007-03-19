using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace km.hl.outturn {
    class BuyerSelect {
        public BuyerSelect(ICollection<orm.MoveOrder> orders, ScanAlgorithm alghoritm) {
            this.orders = orders;
            this.alghoritm = alghoritm;
        }
        private ICollection<orm.MoveOrder> orders;
        private ScanAlgorithm alghoritm;

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
            container.AutoScrollPosition = new Point(0, 0);
            int top = 0;
            for (int i = 0; i < buyers.Length; i++) {
                BuyerItem item = new BuyerItem(buyers[i], orders, alghoritm);
                item.Top = top;
                container.Controls.Add(item);
                top += item.Height + 1;
            }
        }

        private class BuyersNameComparasion : IComparer<orm.Buyer> {
            public int Compare(km.hl.orm.Buyer x, km.hl.orm.Buyer y) {
                return x.Description.CompareTo(y.Description);
            }
        }
    }
}
