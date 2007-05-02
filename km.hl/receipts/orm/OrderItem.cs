using System;
using System.Collections.Generic;
using System.Text;

using g.orm.impl;

namespace km.hl.receipts.orm {
    public class OrderItem : GenericORMObject {
        public OrderItem(OrderItemKey key) : base(key) {
            mfrExtCodes = new ObjectsList<String>(this, new List<String>(), false);
        }

        public OrderItem(OrderItemKey key, Order order) : this(key) {
            this.order = order;
        }

        public OrderItem(OrderItemKey key, Order order, int inventoryItemId, String intCode, String description) : this(key) {
            this.order = order;
            this.inventoryItemId = inventoryItemId;
            this.internalCode = intCode;
            this.description = description;
        }

        public int SqType {
            get { return ((OrderItemKey)ORMKey).SqType; }
        }

        public int Id {
            get { return ((OrderItemKey)ORMKey).Id; }
        }

        private Order order;
        public Order Order {
            get { return order; }
            set { checkRo("order");  order = value; }
        }

        private int quantity;
        public int Quantity {
            get { return quantity; }
            set { checkRo("quantity"); quantity = value; }
        }

        private int quantity_checked;
        public int QuantityChecked {
            get { return quantity_checked; }
            set { quantity_checked = value; markDirty(); }
        }

        private int inventoryItemId;
        public int InventoryItemId {
            get { return inventoryItemId; }
            set { checkRo("inverntoryItemId");  inventoryItemId = value; }
        }

        private String description;
        public String Description {
            get { return description; }
            set { checkRo("description"); description = value; }
        }

        private String internalCode;
        public String InternalCode {
            get { return internalCode; }
            set { checkRo("intCode");  internalCode = value; }
        }
        private String mfrCode;

        public String MfrCode {
            get { return mfrCode; }
            set { mfrCode = value; markDirty(); }
        }

        private String attribute;
        public String Attribute {
            get { return attribute; }
            set { checkRo("attribute"); attribute = value; }
        }

        private bool noSerials;
        public bool NoSerials {
            get { return noSerials; }
            set { noSerials = value; markDirty();  }
        }

        private IList<String> mfrExtCodes = null;
        public IList<String> MfrExtCodes {
            get { return mfrExtCodes; }
        }

        public bool IsRightCode(String code) {
            code = code.ToUpper();
            if (String.IsNullOrEmpty(code)) return false;
            if (MfrCode != null) {
                if (code.IndexOf(MfrCode.ToUpper()) >= 0) return true;
            }
            if (InternalCode != null) {
                if (code == InternalCode.ToUpper()) return true;
                if (code.Length + 2 == InternalCode.Length && InternalCode.ToUpper().StartsWith(code + "/")) return true;
            }
            foreach (String c in mfrExtCodes) {
                if (code.IndexOf(c) >= 0) return true;
            }
            return false;
        }

        private ICollection<OrderItemSerial> serials = new List<OrderItemSerial>();
        public ICollection<OrderItemSerial> Serials {
            get { return serials; }
        }

        public interface IOrderItemMapper {
            ICollection<OrderItem> getItemsForOrder(IntKey itemKey);
            ICollection<OrderItem> getItemsByIntCode(String code);
            ICollection<OrderItem> getItemsByMfrCode(String code);
        }
    }
}
