using System;
using System.Collections.Generic;
using System.Text;

namespace km.hl.outturn {
    public interface ScanAlgorithm {
        void process(ItemsForm form, ICollection<ItemView> items);

        void processItemView(ItemsForm itemsForm, ICollection<ItemView> views);

        void scanSerial(SerialsForm serialsForm, ICollection<ItemView> views);

        void removeSerial(SerialsForm serialsForm, ICollection<ItemView> views, string serial);

        void initSelectTypeForm(SelectListTypeForm form);
    }
}
