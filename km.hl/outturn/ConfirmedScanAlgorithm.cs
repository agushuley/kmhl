﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using km.hl.orm;
using g.orm;
using km.hl.outturn.orm;

namespace km.hl.outturn {
    public class ConfirmedScanAlgorithm : ScanAlgorithm {
        public ConfirmedScanAlgorithm() {
            String v = g.config.Config.get("outturn.min.items.without.serials");
            if (v != null) {
                _minItemsWoSerials = Int32.Parse(v);
            }
        }

        public void process(ItemsForm form, ICollection<ItemView> selected) {
            form.closeHandQtyInput();
            form.hideAlert();

            bool unpickedFound = false;
            bool noSerialNeed = false;
            foreach (ItemView itemView in selected) {
                if (itemView.Item.Quantity > itemView.Item.QtyPicked) {
                    unpickedFound = true;
                }
                if (itemView.Item.NoSerialNeed) {
                    noSerialNeed = true;
                }
            }

            if (!unpickedFound) {
                Program.playMinor();
                form.alert("Все количество позиции отобрано");
                return;
            }

            if (!noSerialNeed) {
                processSerials(form, selected);
            } // need serial
            else {
                foreach (ItemView view in selected) {
                    if (view.Item.QtyPicked < view.Item.Quantity) {
                        view.Item.QtyPicked++;
                        view.redraw();
                        break;
                    }
                }
                OrmContext.Instance.commit();
                Program.playMajor();
            } // if (!serialNeed)
            checkClosed(selected);
        }

        private void checkClosed(ICollection<ItemView> selected) {
            Iesi.Collections.ISet orders = new Iesi.Collections.HashedSet();
            foreach (ItemView item in selected) {
                orders.Add(item.Item.Order);
            }
            foreach (MoveOrder order in orders) {
                bool completed = true;
                foreach (MoveOrderItem item in order.Items) {
                    if (item.QtyPicked < item.Quantity) {
                        completed = false;
                        break;
                    }
                }
                order.Complete = completed;
                OrmContext.Instance.commit();
            }
        }


        public void processItemView(ItemsForm itemsForm, ICollection<ItemView> views) {
            processSerials(itemsForm, views);
        }

        private int _minItemsWoSerials = 20;

        private void processSerials(ItemsForm form, ICollection<ItemView> selected) {
            SerialsForm serials = new SerialsForm(selected, this);
            DialogResult result = serials.ShowDialog();
            if (result != DialogResult.Cancel) {
                bool noSerialNeed = false;
                int qty = 0;
                foreach (ItemView itemView in selected) {
                    itemView.redraw();
                    qty += itemView.Item.Quantity;
                    noSerialNeed = noSerialNeed || itemView.Item.NoSerialNeed;
                }
                if (qty > _minItemsWoSerials && noSerialNeed) {
                    form.createHandQtyInput(selected);
                }
            }
        }

        public void scanSerial(SerialsForm serials, ICollection<ItemView> views) {
            if (String.IsNullOrEmpty(serials.tbSerial.Text) && !serials.NoSerialsNeed) {
                Program.playMinor();
                serials.alert("Серийный номер пуст");
                return;
            }

            if (!serials.NoSerialsNeed) {
                if (Commons.checkSerialIsItemCode(serials.tbSerial.Text)) {
                    Program.playMinor();
                    serials.alert("Серийный некорректен");
                    return;
                }
            }

            if (serials.NoSerialsChanged) {
                foreach (ItemView view in views) {
                    view.Item.NoSerialNeed = serials.NoSerialsNeed;
                }
                OrmContext.Instance.commit();
            }

            if (!serials.NoSerialsNeed) {
                if (Commons.checkSerialExists(serials.tbSerial.Text)) {
                    Program.playMinor();
                    serials.alert("Дублирование серийного номера");
                    return;
                }
            }

            foreach (ItemView view in views) {
                if (view.Item.QtyPicked < view.Item.Quantity) {
                    if (!serials.NoSerialsNeed) {
                        ItemSerial serial = new ItemSerial(view.Item, serials.tbSerial.Text);
                        Mapper serialsMapper = OrmContext.Instance.getMapper(typeof(ItemSerial));
                        serialsMapper.add(serial);
                        view.Item.Serials.Add(serial);
                    }

                    view.Item.QtyPicked++;

                    OrmContext.Instance.commit();
                    break;
                }
            }
            serials.DialogResult = DialogResult.OK;
            serials.Close();
            checkClosed(views);
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
                        if (view.Item.QtyPicked > 0) {
                            view.Item.QtyPicked--;
                            view.redraw();
                        }
                        OrmContext.Instance.commit();
                        serials.listSerials.Items.Remove(serial);
                    }
                }
            }
        }

        public void initSelectTypeForm(SelectListTypeForm form) {
            form.selectByDocument();
        }
    }
}
