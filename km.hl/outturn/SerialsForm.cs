using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using km.hl.orm;
using g.orm;

namespace km.hl.outturn {
    public partial class SerialsForm : Form {
        public SerialsForm(ICollection<MoveOrderItem> items) {
            InitializeComponent();

            this.items = items;
        }

        private ICollection<MoveOrderItem> items;

        private void SerialsForm_Load(object sender, EventArgs e) {
            foreach (MoveOrderItem item in items) {
                cbNoSerialNeed.Checked = item.NoSerialNeed;
                foreach (ItemSerial s in item.Serials) {
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
            if (String.IsNullOrEmpty(tbSerial.Text) && !NoSerialsNeed) {
                Program.playMinor();
                this.Text = "Серийный номер пуст";
                return;
            }

            if (!NoSerialsNeed) {
                foreach (MoveOrderItem item in items) {
                    if (item.IsRightCode(tbSerial.Text)) {
                        Program.playMinor();
                        this.Text = "Серийный некорректен";
                        return;
                    }
                }
            }

            if (noSerialsChanged) {
                foreach (MoveOrderItem item in items) {
                    item.NoSerialNeed = NoSerialsNeed;
                }
                Context.Instance.commit();
            }

            if (!NoSerialsNeed) {
                foreach (MoveOrderItem item in items) {
                    foreach (ItemSerial s in item.Serials) {
                        if (s.Serial == tbSerial.Text) {
                            Program.playMinor();
                            this.Text = "Дублирование серийного номера";
                            return;
                        }
                    }
                }
            }

            foreach (MoveOrderItem item in items) {
                if (item.QtyPicked < item.Quantity) {
                    if (!NoSerialsNeed) {
                        ItemSerial serial = new ItemSerial(item, this.tbSerial.Text);
                        Mapper serialsMapper = orm.Context.Instance.getMapper(typeof(ItemSerial));
                        serialsMapper.add(serial);
                        item.Serials.Add(serial);
                    }

                    item.QtyPicked++;

                    orm.Context.Instance.commit();
                    break;
                }
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e) {
            scan();
        }

        public bool NoSerialsNeed {
            get { return cbNoSerialNeed.Checked;  }
        }

        private bool noSerialsChanged = false;
        private void cbNoSerialNeed_CheckStateChanged(object sender, EventArgs e) {
            noSerialsChanged = true;
        }
    }
}