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
            if (state == km.hl.orm.MoveOrderSate.C) {
                algorithm = new ConfirmedScanAlgorithm();
            }
            else if (state == km.hl.orm.MoveOrderSate.G) {
                algorithm = new GivedScanAlgorithm();
            } else {
                algorithm = new NullScanAlghoritm();
            }
        }

        private ScanAlgorithm algorithm;
        private orm.MoveOrderSate state;

        private void btnContragents_Click(object sender, EventArgs e) {
            selectByBuyer();
        }

        ICollection<orm.MoveOrder> orders = new List<orm.MoveOrder>();
        private void SelectViewForm_Load(object sender, EventArgs e) {
            foreach (orm.MoveOrder order in orm.Context.Instance.getMapper(typeof(orm.MoveOrder)).getAll()) {
                if (order.State == this.state) {
                    orders.Add(order);
                }
            }
            algorithm.initSelectTypeForm(this);
        }

        private void X_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnDocuments_Click(object sender, EventArgs e) {
            selectByDocument();
        }

        internal void selectByDocument() {
            panel.Controls.Clear();
            OrderSelect select = new OrderSelect(orders, algorithm);
            select.load(panel);
        }

        internal void selectByBuyer() {
            panel.Controls.Clear();
            BuyerSelect select = new BuyerSelect(orders, algorithm);
            select.load(panel);
        }
    }
}