using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace km.hl.outturn {
    class BuyerItem : Button {
        public BuyerItem(orm.Buyer buyer, ICollection<orm.MoveOrder> orders, ScanAlgorithm alghoritm) {

            Text = String.Format("{0} ({1})", buyer.Description, buyer.Id);
            this.buyer = buyer;
            this.orders = orders;
            this.alghoritm = alghoritm;
        }
        private ScanAlgorithm alghoritm;

        protected override void OnClick(EventArgs e) {
            base.OnClick(e);

            List<orm.MoveOrderItem> items = new List<orm.MoveOrderItem>();
            foreach (orm.MoveOrder order in orders) {
                if (order.Buyer == buyer) {
                    items.AddRange(order.Items);
                }
            }
            new ItemsForm(items, alghoritm).ShowDialog();
        }

        orm.Buyer buyer;
        ICollection<orm.MoveOrder> orders;
    }
}
