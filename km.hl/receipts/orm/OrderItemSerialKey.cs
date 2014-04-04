using System;
using System.Collections.Generic;
using System.Text;

using g.orm.impl;

namespace km.hl.receipts.orm {
    public class OrderItemSerialKey : AbstractKey {
        public OrderItemSerialKey(int sqType, int id, String serial) {
            this.serial = serial;
            this.sqType = sqType;
            this.id = id;
        }

        public OrderItemSerialKey(OrderItemKey itemKey, String serial) : this(itemKey.SqType, itemKey.Id, serial) {
        }

        private String serial;
        public String Serial {
            get { return serial; }
        }

        private int sqType;
        public int SqType {
            get { return sqType; }
        }

        private int id;
        public int Id {
            get { return id; }
        }

        public override object[] Values {
            get { return new Object[] { sqType, id, serial }; }
        }
    }
}
