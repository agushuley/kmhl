using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace km.hl.receipts {
    public partial class NewItemForm : Form {
        public NewItemForm() {
            InitializeComponent();
        }

        public String Caption {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }

        public String Code {
            get { return tbCode.Text; }
            set { tbCode.Text = value; }
        }

        private void btnCreate_Click(object sender, EventArgs e) {

        }

        private void NewItemForm_Closing(object sender, CancelEventArgs e) {
            if (DialogResult == DialogResult.OK) {
                if (String.IsNullOrEmpty(tbName.Text.Trim())) {
                    MessageBox.Show("Название позиции пустое!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    e.Cancel = true;
                    return;
                }
                if (String.IsNullOrEmpty(tbCode.Text.Trim())) {
                    MessageBox.Show("Код производителя пустой!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    e.Cancel = true;
                    return;
                }
            }
        }
    }
}