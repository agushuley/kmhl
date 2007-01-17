using System;
using System.Collections.Generic;
using System.Text;
using g.orm.impl;

namespace km.hl.orm {
    public class MoveOrderItem : GenericORMObject {
        public MoveOrderItem(IntKey key) : base(key) {}

        private MoveOrder order;
        public MoveOrder Order {
            get { return order; }
            set { checkRo("order"); order = value; }
        }

        private int quantity;
        public int Quantity {
            get { return quantity; }
            set { checkRo("quantity"); quantity = value; }
        }

        private int inventoryId;
        public int InventoryId {
            get { return inventoryId; }
            set { checkRo("inventoryId"); inventoryId = value; }
        }

        private String description;
        public String Description {
            get { return description; }
            set { checkRo("description"); description = value; }
        }

        private String internalCode;
        public String InternalCode {
            get { return internalCode; }
            set { checkRo("internalCode"); internalCode = value; }
        }

        private String mfrCode;
        public String MfrCode {
            get { return mfrCode; }
            set { checkRo("mfrCode"); mfrCode = value; }
        }
    }
}
