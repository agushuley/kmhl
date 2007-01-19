using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace km.hl.outturn {
    public partial class BuyerItem : UserControl {
        public BuyerItem(orm.Buyer buyer, ICollection<orm.MoveOrder> orders) {
            InitializeComponent();

            button1.Text = String.Format("{0} ({1})", buyer.Description, buyer.Id);
            this.buyer = buyer;
            this.orders = orders;
        }

        orm.Buyer buyer;
        ICollection<orm.MoveOrder> orders;

        private void button1_Click(object sender, EventArgs e) {
            MessageBox.Show(buyer.Description);
        }
    }
}
