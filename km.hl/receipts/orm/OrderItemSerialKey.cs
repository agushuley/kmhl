using System;
using System.Collections.Generic;
using System.Text;

namespace km.hl.receipts.orm {
    public class OrderItemSerialKey : OrderItemKey {
        public OrderItemSerialKey(int seqType, int id, String serial) : base(seqType, id) {
            this.serial = serial;
        }

        private String serial;
        public String Serial {
            get { return serial; }
        }

        public override object[] Values {
            get {
                return new Object[] { Id, SqType, Serial };
            }
        }
    }
}
