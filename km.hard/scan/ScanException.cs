using System;
using System.Collections.Generic;
using System.Text;

namespace km.hard.scan {
    public class ScanException : Exception {
        public ScanException(String ex)
            : base(ex) {
        }
    }
}
