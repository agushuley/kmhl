using System;
using System.Collections.Generic;
using System.Text;

namespace g.orm.impl {
    public class IntKey : AbstractKey {
        public IntKey(int _int) {
            this._int = _int;
        }

        private int _int;
        public int Int {
            get { return _int; }
        }

        public override Object[] Values {
            get { return new Object[] {_int}; }
        }
    }
}
