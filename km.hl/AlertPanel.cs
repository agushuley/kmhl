using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace km.hl {
    public partial class AlertPanel : UserControl {
        public AlertPanel() {
            InitializeComponent();
        }

        private void AlertPanel_Click(object sender, EventArgs e) {
            Visible = false;
        }
    }
}
