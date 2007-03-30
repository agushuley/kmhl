using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using g.orm;
using km.hl.orm;

namespace km.hl.receipts {
    public partial class SerialsForm : AlertForm {
        public SerialsForm(ICollection<ItemView> views) {
            InitializeComponent();

            this.views = views;
        }

        private ICollection<ItemView> views;

        private void SerialsForm_Load(object sender, EventArgs e) {
            foreach (ItemView view in views) {
                cbNoSerialNeed.Checked = view.Item.NoSerials;
                foreach (orm.OrderItemSerial s in view.Item.Serials) {
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
                alert("Серийный номер пуст");
                return;
            }

            if (!NoSerialsNeed) {
/*                if (Commons.checkSerialIsItemCode(serials.tbSerial.Text)) {
                    Program.playMinor();
                    serials.alert("Серийный некорректен");
                    return;
                } */
                /* TODO: Serials check */

            }

            if (NoSerialsChanged) {
                foreach (ItemView view in views) {
                    view.Item.NoSerials = NoSerialsNeed;
                }
                OrmContext.Instance.commit();
            }

            if (!NoSerialsNeed) {
/*                if (Commons.checkSerialExists(serials.tbSerial.Text)) {
                    Program.playMinor();
                    serials.alert("Дублирование серийного номера");
                    return;
                } */
            }

            foreach (ItemView view in views) {
                if (view.Item.QuantityChecked < view.Item.Quantity) {
                    if (!NoSerialsNeed) {
                        orm.OrderItemSerial serial = new orm.OrderItemSerial(new orm.OrderItemSerialKey((orm.OrderItemKey)view.Item.ORMKey, tbSerial.Text), view.Item);
                        Mapper serialsMapper = OrmContext.Instance.getMapper(typeof(orm.OrderItemSerial));
                        serialsMapper.add(serial);
                        view.Item.Serials.Add(serial);
                    }

                    view.Item.QuantityChecked++;

                    OrmContext.Instance.commit();
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

                    orm.OrderItemSerial serialToRemove = null;
                    foreach (ItemView view in views) {
                        try {
                            foreach (orm.OrderItemSerial serialObj in view.Item.Serials) {
                                if (serial == serialObj.Serial) {
                                    serialToRemove = serialObj;
                                    break;
                                }
                            }
                        }
                        finally {
                            if (serialToRemove != null) {
                                serialToRemove.Remove();
                                view.Item.Serials.Remove(serialToRemove);
                                if (view.Item.QuantityChecked > 0) {
                                    view.Item.QuantityChecked--;
                                }
                                OrmContext.Instance.commit();
                                view.redraw();
                                listSerials.Items.Remove(serial);
                            }
                        }
                    }
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