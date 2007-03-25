using System;
using System.Collections.Generic;
using System.Text;

namespace g.orm.impl {
    public class StringKey : AbstractKey {
        public StringKey(String str) {
            this.str = str;
        }

        String str;
        public override object[] Values {
            get { return new Object[] { str }; }
        }

        public override string ToString() {
            return str;
        }
    }
}
