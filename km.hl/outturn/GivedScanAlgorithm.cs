using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using km.hl.orm;
using g.orm;
using km.hl.outturn.orm;

namespace km.hl.outturn {
    public class GivedScanAlgorithm : ScanAlgorithm {
        public void process(ItemsForm form, ICollection<ItemView> selected) {
            form.closeHandQtyInput();
            form.hideAlert();

            bool filled = true;
            foreach (ItemView itemView in selected) {
                if (itemView.Item.Serials.Count < itemView.Item.Quantity) {
                    filled = false;
                    break;
                }
            }
            if (filled) {
                Program.playMinor();
                form.alert("Все серийные номера позиции заполнены");
                return;
            };


            processSerials(form, selected);
        }

        public void processItemView(ItemsForm itemsForm, ICollection<ItemView> views) {
            processSerials(itemsForm, views);
        }

        private void processSerials(ItemsForm form, ICollection<ItemView> selected) {
            SerialsForm serials = new SerialsForm(selected, this);
            serials.NoSerialNeedVisible = false;
            DialogResult result = serials.ShowDialog();
            foreach (ItemView itemView in selected) {
                itemView.redraw();
            }
        }

        public void scanSerial(SerialsForm serialsForm, ICollection<ItemView> views) {
            if (String.IsNullOrEmpty(serialsForm.tbSerial.Text)) {
                Program.playMinor();
                serialsForm.alert("Серийный номер пуст");
                return;
            }

            if (Commons.checkSerialIsItemCode(serialsForm.tbSerial.Text)) {
                Program.playMinor();
                serialsForm.alert("Серийный некорректен");
                return;
            }

            if (Commons.checkSerialExists(serialsForm.tbSerial.Text)) {
                Program.playMinor();
                serialsForm.alert("Дублирование серийного номера");
                return;
            }

            bool filled = isFilled(views);
            if (filled) {
                Program.playMinor();
                serialsForm.alert("Все серийные номера позиции заполнены");
                return;
            };

            foreach (ItemView view in views) {
                if (view.Item.Serials.Count < view.Item.Quantity) {
                    ItemSerial serial = new ItemSerial(view.Item, serialsForm.tbSerial.Text);
                    Mapper serialsMapper = OrmContext.Instance.getMapper(typeof(ItemSerial));
                    serialsMapper.add(serial);
                    view.Item.Serials.Add(serial);

                    OrmContext.Instance.commit();

                    serialsForm.listSerials.Items.Add(serialsForm.tbSerial.Text);
                    serialsForm.tbSerial.Text = "";

                    break;
                }
            }

            if (isFilled(views)) {
                serialsForm.DialogResult = DialogResult.OK;
                serialsForm.Close();
                Program.playMajor();
            }
        }

        private static bool isFilled(ICollection<ItemView> views) {
            foreach (ItemView itemView in views) {
                if (itemView.Item.Serials.Count < itemView.Item.Quantity) {
                    return false;
                }
            }
            return true;
        }

        public void removeSerial(SerialsForm serials, ICollection<ItemView> views, string serial) {
            ItemSerial serialToRemove = null;
            foreach (ItemView view in views) {
                try {
                    foreach (orm.ItemSerial serialObj in view.Item.Serials) {
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
                        view.redraw();
                        OrmContext.Instance.commit();
                        serials.listSerials.Items.Remove(serial);
                    }
                }
            }
        }

        public void initSelectTypeForm(SelectListTypeForm form) {
            form.selectByBuyer();
        }
    }
}
