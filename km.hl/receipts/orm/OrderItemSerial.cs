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

        public interface IOrdersItemsSerialsMapper {
            ICollection<ORMObject> getSerialsForItem(OrderItemKey key);
        }
    }
}
