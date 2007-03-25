using System;
using System.Collections.Generic;
using System.Text;
using g.orm.impl;

namespace km.hl.receipts.orm {
    public class OrderItemKey : AbstractKey {
        public OrderItemKey(int sqType, int id) {
            this.sqType = sqType;
            this.id = id;
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
            get { return new Object[] { sqType, id }; }
        }
    }
}
