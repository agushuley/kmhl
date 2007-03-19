using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using km.hl.orm;
using g.orm;

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

            bool filled = true;
            foreach (ItemView itemView in views) {
                if (itemView.Item.Serials.Count < itemView.Item.Quantity) {
                    filled = false;
                    break;
                }
            }
            if (filled) {
                Program.playMinor();
                serialsForm.alert("Все серийные номера позиции заполнены");
                return;
            };

            foreach (ItemView view in views) {
                if (view.Item.Serials.Count < view.Item.Quantity) {
                    ItemSerial serial = new ItemSerial(view.Item, serialsForm.tbSerial.Text);
                    Mapper serialsMapper = orm.Context.Instance.getMapper(typeof(ItemSerial));
                    serialsMapper.add(serial);
                    view.Item.Serials.Add(serial);

                    orm.Context.Instance.commit();

                    serialsForm.listSerials.Items.Add(serialsForm.tbSerial.Text);
                    serialsForm.tbSerial.Text = "";

                    break;
                }
            }
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
                        Context.Instance.commit();
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
