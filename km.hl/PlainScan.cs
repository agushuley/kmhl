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

        private bool saved = true;
        private String fileName = null;
        private String FileName {
            get {
                if (fileName == null) {
                    if (saveDlg.ShowDialog() == DialogResult.OK) {
                        fileName = saveDlg.FileName;
                    }
                }
                return fileName;
            }
        }

        private void PlainScan_Load(object sender, EventArgs e) {
            Scanner s = Program.getScanner();
            s.Scanned += new OnScanned(s_Scanned);
            s.Attach(this);
        }

        void s_Scanned(string code) {
            codes.Text += code += "\r\n";
            codes.SelectionStart = codes.Text.Length;
            codes.SelectionLength = 0;
            codes.ScrollToCaret();
            codes.ScrollToCaret();
        }

        private void close_Click(object sender, EventArgs e) {
            Close();
        }

        protected override void OnClosing(CancelEventArgs e) {
            if (!(codes.Text.Trim() == "" && saved)) {
                switch (MessageBox.Show("Вы хотите сохранить отсканированый буфер?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)) {
                    case DialogResult.Yes:
                        save();
                        if (!saved) {
                            e.Cancel = true;
                        }
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
            base.OnClosing(e);
        }

        private void btnStore_Click(object sender, EventArgs e) {
            save();
        }

        private void save() {
            if (!saved) {
                String file = FileName;
                if (file != null) {
                    using (System.IO.StreamWriter w = new System.IO.StreamWriter(file)) {
                        w.Write(codes.Text);
                        w.Flush();
                    }
                    saved = true;
                }
            }
        }

        private void codes_TextChanged(object sender, EventArgs e) {
            saved = false;
        }
    }
}