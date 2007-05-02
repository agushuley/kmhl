using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace km.hl {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        private void btnOutturnChecked_Click(object sender, EventArgs e) {
            new outturn.SelectListTypeForm(outturn.orm.MoveOrderSate.C).ShowDialog();
        }

        private void btnOutturnGivved_Click(object sender, EventArgs e) {
            new outturn.SelectListTypeForm(outturn.orm.MoveOrderSate.G).ShowDialog();
        }

        private void MainForm_Closing(object sender, CancelEventArgs e) {
            orm.OrmContext.Instance.close();
        }

        private void btnOutturnSync_Click(object sender, EventArgs e) {
            new SyncForm().ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e) {
            Close();
        }

        private void button1_Click(object sender, EventArgs e) {
            new PlainScan().ShowDialog();
        }


        private void MainForm_Load(object sender, EventArgs e) {
            version.Text = "Version: " + Program.VERSION;
        }

        private void btnReceips_Click(object sender, EventArgs e) {
            new receipts.OrdersForm().ShowDialog();
        }
    }
}