using System;
using System.Collections.Generic;
using System.Text;

namespace km.hl.dom.junius {
    public class Order : g.orm.ORMObject {
        public Order(g.orm.impl.IntKey key) : base(key) { }

        public int Id {
            get {
                if (Key == null) return 0;
                return ((g.orm.impl.IntKey)Key).Int;
            }
        }

        private DateTime date;
        public DateTime Date {
            get { return date; }
            set { date = value; markDirty(); }
        }

        private byte status;
        public byte Status {
            get { return status; }
            set { status = value; markDirty();  }
        }

        private String name;
        public String Name {
            get { return name; }
            set { name = value; markDirty(); }
        }

        private String description;
        public String Description {
            get { return description; }
            set { description = value; markDirty();  }
        }

        private ICollection<OrderDetail> details = null;
        internal ICollection<OrderDetail> Details {
            get {
                if (details == null) {
                    details = detailsLoader.load(this);
                    detailsLoader = null;
                }
                return details; 
            }
        }

        internal g.orm.DeferableLoader<OrderDetail, Order> detailsLoader = null;

        protected override void DoRemove() {
            foreach (OrderDetail d in details) {
                d.Remove();
            }
        }
    }
}
