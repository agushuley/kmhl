using System;
using System.Collections.Generic;
using System.Text;

namespace km.hl.dom.junius {
    class OrderDetail : g.orm.impl.AbstractORMObject {
        internal class OrderDetailsKey : g.orm.impl.AbstractKey {
            internal int order, line;
            internal OrderDetailsKey(int order, int line) {
                this.order = order;
                this.line = line;
            }

            public override Object[] Values {
                get { return new Object[] { order, line }; }
            }
        };

        public OrderDetail(OrderDetailsKey key) : base (key) {
        }

        public int OrderId {
            get { return ((OrderDetailsKey)Key).order; }
        }

        public int Line {
            get { return ((OrderDetailsKey)Key).line; }
        }

        private Order order;
        public Order Order {
            get { return order; }
            internal set { checkRo("Order"); order = value; }
        }

        private DateTime date;
        public DateTime Date {
            get { return date; }
            set { date = value; markDirty(); }
        }

        private String description;
        public String Description {
            get { return description; }
            set { description = value; markDirty(); }
        }

        private int ordered;
        public int Ordered {
            get { return ordered; }
            set { ordered = value; markDirty(); }
        }

        private int shipped;
        public int Shipped {
            get { return shipped; }
            set { shipped = value; markDirty();  }
        }

        private int received;
        public int Received {
            get { return received; }
            set { received = value; markDirty(); }
        }

        private decimal cost;
        public decimal Cost {
            get { return cost; }
            set { cost = value; markDirty(); }
        }
    }
}
