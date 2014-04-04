using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace km.hl.receipts {
    public partial class OrderStatusForm : Form {
        public OrderStatusForm() {
            InitializeComponent();
        }


        public bool Status {
            get { return stateReady.Checked;  }
            set { stateReady.Checked = value; stateNotReady.Checked = !value; }
        }
    }
}