using System;
using System.Collections.Generic;
using System.Text;

using km.hard.scan;

namespace km.hard.stubs {
    class BarScanner : Scanner {
        public void Attach(System.Windows.Forms.Form form) {
        }

        public event OnScanned Scanned;
    }
}
