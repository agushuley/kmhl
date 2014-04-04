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

        public static ICollection<T1> convertCollection<T1>(g.orm.ORMObject[] objects) {
            ICollection<T1> list = new List<T1>();
            foreach (T1 t in objects) {
                list.Add(t);
            }
            return list;
        }
    }
}
