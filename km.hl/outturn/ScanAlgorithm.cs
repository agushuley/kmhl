using System;
using System.Collections.Generic;
using System.Text;

namespace km.hl.outturn {
    public interface ScanAlgorithm {
        void process(ItemsForm form);
    }
}
