using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace km.hl {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        private void btnOutturnChecked_Click(object sender, EventArgs e) {
            new outturn.SelectListTypeForm(orm.MoveOrderSate.C).ShowDialog();
        }

        private void btnOutturnGivved_Click(object sender, EventArgs e) {
            new outturn.SelectListTypeForm(orm.MoveOrderSate.G).ShowDialog();
        }

        private void MainForm_Closing(object sender, CancelEventArgs e) {
            orm.Context.Instance.close();
        }

        private void btnOutturnSync_Click(object sender, EventArgs e) {
            new SyncForm().ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e) {
            Close();
        }
    }
}