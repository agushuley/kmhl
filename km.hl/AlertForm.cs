using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace km.hl {
    public partial class AlertForm : Form {
        public AlertForm() {
            InitializeComponent();
        }

        public void alert(String alert) {
            this.alertPanel.lblInfo.Text = alert;
            this.alertPanel.Show();
            this.alertPanel.BringToFront();
        }

        public void hideAlert() {
            this.alertPanel.Visible = false;
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            this.alertPanel.Top = ClientRectangle.Height - 2 - 59;
            this.alertPanel.Height = 59; 
        }
    }
}