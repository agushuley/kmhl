using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using g.orm;
using km.hl.outturn.orm;

namespace km.hl.outturn {
    public partial class SerialsForm : AlertForm {
        public SerialsForm(ICollection<ItemView> views, ScanAlgorithm algorithm) {
            InitializeComponent();

            this.views = views;
            this.algorithm = algorithm;
        }

        private ICollection<ItemView> views;
        private ScanAlgorithm algorithm;

        private void SerialsForm_Load(object sender, EventArgs e) {
            foreach (ItemView view in views) {
                cbNoSerialNeed.Checked = view.Item.NoSerialNeed;
                foreach (ItemSerial s in view.Item.Serials) {
                    listSerials.Items.Add(s.Serial);
                }
            }
            km.hard.scan.Scanner scanner = Program.getScanner();
            scanner.Attach(this);
            scanner.Scanned += new km.hard.scan.OnScanned(scanner_Scanned);
        }

        void scanner_Scanned(string code) {
            this.tbSerial.Text = code;
            scan();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            Close();
        }

        void scan() {
            algorithm.scanSerial(this, views);
        }

        private void btnOk_Click(object sender, EventArgs e) {
            scan();
        }

        public bool NoSerialsNeed {
            get { return cbNoSerialNeed.Checked;  }
        }

        private bool noSerialsChanged = false;
        public bool NoSerialsChanged {
            get { return noSerialsChanged; }
        }
        private void cbNoSerialNeed_CheckStateChanged(object sender, EventArgs e) {
            noSerialsChanged = true;
        }

        private void listSerials_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Back) {
                if (listSerials.SelectedIndex != -1) {
                    String serial = (String)listSerials.SelectedItem;
                    algorithm.removeSerial(this, views, serial);
                }
                else {
                    Program.playMajor();
                    alert("Не выделен серийный номер");
                }
            }
        }

        public bool NoSerialNeedVisible {
            get { return cbNoSerialNeed.Visible; }
            set { cbNoSerialNeed.Visible = value; }
        }
    }
}