using System;
using System.Collections.Generic;
using System.Text;

namespace km.hl {
    public static class HlTools {
        public static ICollection<String> splitCodes(String codes) {
            ICollection<String> cc = new List<String>();
            if (codes != null) {
                foreach (String code in codes.Split('/')) {
                    if (!String.IsNullOrEmpty(code) && !String.IsNullOrEmpty(code.Trim())) {
                        cc.Add(code);
                    }
                }
            }
            return cc;
        }
    }
}
