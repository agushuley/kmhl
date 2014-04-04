using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace km.hard.scan {
    public delegate void OnScanned(String code);

    public interface Scanner {
        void Attach(Form owner);
        event OnScanned Scanned;
    }
}
