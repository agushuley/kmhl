using System;
using System.Collections.Generic;
using System.Text;

namespace km.hl.outturn {
    class NullScanAlghoritm : ScanAlgorithm{
        #region ScanAlgorithm Members

        public void process(ItemsForm form, ICollection<ItemView> items) {
            throw new Exception("The method or operation is not implemented.");
        }

        public void processItemView(ItemsForm itemsForm, ICollection<ItemView> views) {
            throw new Exception("The method or operation is not implemented.");
        }

        public void scanSerial(SerialsForm serialsForm, ICollection<ItemView> views) {
            throw new Exception("The method or operation is not implemented.");
        }

        public void removeSerial(SerialsForm serialsForm, ICollection<ItemView> views, string serial) {
            throw new Exception("The method or operation is not implemented.");
        }

        public void initSelectTypeForm(SelectListTypeForm form) {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
