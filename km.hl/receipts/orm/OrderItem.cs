using System;
using System.Collections.Generic;
using System.Text;

using g.orm.impl;

namespace km.hl.receipts.orm {
    public class OrderItem : GenericORMObject {
        public OrderItem(OrderItemKey key) : base(key) {
            mfrExtCodes = new ObjectsList<Object>(this, new List<Object>(), false);
        }

        public int SqType {
            get { return ((OrderItemKey)ORMKey).SqType; }
        }

        public int Id {
            get { return ((OrderItemKey)ORMKey).Id; }
        }

        private Order order;
        private int quantity;
        private int quantity_checked;
        private int inventoryItemId = -1;
        private String itemDescription;
        private String internalCode = "-1";
        private String mfrCode;
        private String attribute;
        private bool noSerials;
        private IList<Object> mfrExtCodes = null;

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

        public interface IOrderItemMapper {
            ICollection<OrderItem> getItemsForOrder(IntKey orderKey);
        }
    }
}
