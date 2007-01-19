using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace km.hl.outturn {
    public partial class SelectListTypeForm : Form {
        public SelectListTypeForm(orm.MoveOrderSate state) {
            InitializeComponent();

            this.state = state;
        }

        private orm.MoveOrderSate state;

        private void btnContragents_Click(object sender, EventArgs e) {
            panel.Controls.Clear();
            BuyerSelect select = new BuyerSelect(orders);
            select.load();
            select.Dock = DockStyle.Fill;
            panel.Controls.Add(select);
        }

        ICollection<orm.MoveOrder> orders = new List<orm.MoveOrder>();
        private void SelectViewForm_Load(object sender, EventArgs e) {
            foreach (orm.MoveOrder order in orm.Context.Instance.getMapper(typeof(orm.MoveOrder)).getAll()) {
                if (order.State == this.state) {
                    orders.Add(order);
                }
            }
        }

        private void X_Click(object sender, EventArgs e) {
            this.Close();
        }       
    }
}