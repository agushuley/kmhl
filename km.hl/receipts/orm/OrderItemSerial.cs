using System;
using System.Collections.Generic;
using System.Text;

using g.orm.impl;
using g.orm;

namespace km.hl.receipts.orm {
    public class OrderItemSerial : GenericORMObject {
        public OrderItemSerial(OrderItemSerialKey key) : base(key) { }
        public OrderItemSerial(OrderItemSerialKey key, OrderItem item) : this(key) {
            this.item = item;
        }

        private OrderItem item;
        public OrderItem Item {
            get { return item; }
            set { checkRo("orderItem"); item = value; }
        }

        public int Id {
            get { return ((OrderItemSerialKey)ORMKey).Id; }
        }

        public int SeqType {
            get { return ((OrderItemSerialKey)ORMKey).SqType; }
        }

        public String Serial {
            get { return ((OrderItemSerialKey)ORMKey).Serial; }
        }

        public interface IOrdersItemsSerialsMapper {
            ICollection<OrderItemSerial> getSerialsForItem(OrderItemKey key);
        }
    }
}
