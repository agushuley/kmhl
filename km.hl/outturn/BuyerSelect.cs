using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace km.hl.outturn {
    public partial class BuyerSelect : UserControl {
        public BuyerSelect(ICollection<orm.MoveOrder> orders) {
            this.orders = orders;
            InitializeComponent();
        }
        ICollection<orm.MoveOrder> orders;

        public void load() {
            ICollection<orm.Buyer> buyersl = new List<orm.Buyer>();
            foreach (orm.MoveOrder order in orders) {
                if (!buyersl.Contains(order.Buyer)) {
                    buyersl.Add(order.Buyer);
                }
            }

            orm.Buyer[] buyers = new km.hl.orm.Buyer[buyersl.Count];
            buyersl.CopyTo(buyers, 0);
            Array.Sort<orm.Buyer>(buyers, new BuyersNameComparasion());

            this.Controls.Clear();
            foreach (orm.Buyer buyer in buyers) {
                BuyerItem item = new BuyerItem(buyer, orders);
                item.Dock = DockStyle.Top;
                this.Controls.Add(item);
            }
        }

        private class BuyersNameComparasion : IComparer<orm.Buyer> {
            public int Compare(km.hl.orm.Buyer x, km.hl.orm.Buyer y) {
                return x.Description.CompareTo(y.Description);
            }
        }
    }
}
