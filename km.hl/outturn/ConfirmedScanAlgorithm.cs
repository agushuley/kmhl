using System;
using System.Collections.Generic;
using System.Text;

namespace km.hl.outturn {
    public class ConfirmedScanAlgorithm : ScanAlgorithm {
        public void process(ItemsForm form) {
            form.closeHandQtyInput();
            form.hideAlert();

            String code = form.code.Text;
            if (String.IsNullOrEmpty(code)) {
                form.alert("Пустой код");
                Program.playMinor();
                return;
            }
            int itemCode = 0;
            foreach (ItemView itemView in form.itemsViews.Controls) {
                orm.MoveOrderItem item = itemView.Item;
                if (item.IsRightCode(code)) {
                    itemCode = item.InventoryId;
                    break;
                }
            }
            if (itemCode == 0) {
                form.alert("Не найдена позиция");
                Program.playMinor();
                return;
            }

            /*            selected.Clear();
            bool unpickedFound = false;
            bool noSerialNeed = false;
            int top = 0;
            foreach (ItemView itemView in itemsViews.Controls) {
                if (itemView.Item.InventoryId == itemCode) {
                    selected.Add(itemView.Item);
                    itemView.Visible = true;
                    itemView.Top = top;
                    top += itemView.Height;
                    if (itemView.Item.Quantity > itemView.Item.QtyPicked) {
                        unpickedFound = true;
                    }
                    if (itemView.Item.NoSerialNeed) {
                        noSerialNeed = true;
                    }
                }
                else {
                    itemView.Visible = false;
                }
            }

            if (!unpickedFound) {
                Program.playMinor();
                this.Text = "Все количество позиции отобрано";
                return;
            }

            if (!noSerialNeed) {
                SerialsForm serials = new SerialsForm(selected);
                DialogResult result = serials.ShowDialog();
                if (result != DialogResult.Cancel) {
                    foreach (ItemView itemView in itemsViews.Controls) {
                        if (itemView.Visible) {
                            itemView.redraw();
                        }
                    }
                    noSerialNeed = false;
                    int qty = 0;
                    foreach (MoveOrderItem item in selected) {
                        qty += item.Quantity;
                        noSerialNeed = noSerialNeed || item.NoSerialNeed;
                    }
                    if (qty > MAX_ITEMS_WOSCAN && noSerialNeed) {
                        createHandQtyInput();
                    }
                }
            }
            else {
                foreach (MoveOrderItem item in selected) {
                    if (item.QtyPicked < item.Quantity) {
                        item.QtyPicked++;
                        break;
                    }
                }
                orm.Context.Instance.commit();
                Program.playMajor();
            }
  */
        }
    }
}
