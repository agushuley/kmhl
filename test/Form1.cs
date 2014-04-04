using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace test {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            try {
                km.hard.scan.Scanner s = new km.hard.casio.CasioBarScanner();
                s.Attach(this);
                s.Scanned += new km.hard.scan.OnScanned(s_Scanned);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        void s_Scanned(string code) {
            textBox1.Text += "\r\n" + code;
        }
    }
}