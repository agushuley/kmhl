using System;
using System.Collections.Generic;
using System.Text;

using g.orm.impl;

namespace km.hl.receipts.orm {
    public class Order : GenericORMObject {
        public Order(IntKey key) : base(key) {}

        private DateTime createDate;
        public DateTime CreateDate {
            get { return createDate; }
            set { checkRo("createDate"); createDate = value; }
        }

        private String number;
        public String Number {
            get { return number; }
            set { checkRo("number"); number = value; }
        }

        private DateTime orderDate;
        public DateTime OrderDate {
            get { return orderDate; }
            set { checkRo("orderDate"); orderDate = value; }
        }

        private String description;
        public String Description {
            get { return description; }
            set { checkRo("description"); description = value; }
        }

        private String status;
        public String Status {
            get { return status; }
            set { checkRo("status"); status = value; }
        }

        private int vendorId;
        public int VendorId {
            get { return vendorId; }
            set { checkRo("vendorId"); vendorId = value; }
        }

        private String vendor;
        public String Vendor {
            get { return vendor; }
            set { checkRo("vendorId"); vendor = value; }
        }

        private bool isComplete;
        public bool IsComplete {
            get { return isComplete; }
            set { isComplete = value; markDirty(); }
        }

        private IList<OrderItem> items = new List<OrderItem>();
        public IList<OrderItem> Items {
            get { return items; }
        }
    }
}
