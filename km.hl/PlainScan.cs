using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using km.hard.scan;

namespace km.hl {
    public partial class PlainScan : AlertForm {
        public PlainScan() {
            InitializeComponent();
        }

        private void PlainScan_Load(object sender, EventArgs e) {
            Scanner s = Program.getScanner();
            s.Scanned += new OnScanned(s_Scanned);
            s.Attach(this);
        }

        void s_Scanned(string code) {
            codes.Text += code += "\r\n";
        }

        private void close_Click(object sender, EventArgs e) {
            if (codes.Text.Trim() != "" && save.ShowDialog() == DialogResult.OK) {
                using (System.IO.StreamWriter w = new System.IO.StreamWriter(save.FileName)) {
                    w.Write(codes);
                    w.Flush();
                }
            }
            Close();
        }
    }
}