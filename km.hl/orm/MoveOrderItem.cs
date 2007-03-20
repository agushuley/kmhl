using System;
using System.Collections.Generic;
using System.Text;
using g.orm.impl;
using g.orm;

namespace km.hl.orm {
    public class MoveOrderItem : GenericORMObject {
        public MoveOrderItem(IntKey key, DefferableLoader<ItemSerial, MoveOrderItem> loader) : base(key) {
            extMfrCodes = new ObjectsCollection<String>(this, new List<String>(), true);
            this.loader = loader;
        }

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

        private int gtyGived;
        public int QtyPicked {
            get { return gtyGived; }
            set { markDirty(); gtyGived = value; }
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

        public int Id {
            get { return ((IntKey)ORMKey).Int; }
        }

        private DefferableLoader<ItemSerial, MoveOrderItem> loader = null;
        private ICollection<ItemSerial> serials = null;
        public ICollection<ItemSerial> Serials {
            get {
                if (serials == null && loader != null) {
                    serials = loader.load(this);
                    if (serials != null) {
                        loader = null;
                    }
                }
                return serials;
            }
        }

        private bool noSerialNeed = false;

        public bool NoSerialNeed {
            get { return noSerialNeed; }
            set { noSerialNeed = value; markDirty(); }
        }

        public bool IsRightCode(String code) {
            code = code.ToUpper();
            if (String.IsNullOrEmpty(code)) return false;
            if (code.IndexOf(MfrCode.ToUpper()) >= 0) return true;
            if (code == InternalCode.ToUpper()) return true;
            if (code.Length + 2 == InternalCode.Length && InternalCode.ToUpper().StartsWith(code + "/")) return true;
            foreach (String c in ExtMfrCodes) {
                if (code.IndexOf(c) >= 0) return true;
            }
            return false;
        }

        private ICollection<String> extMfrCodes;

        public ICollection<String> ExtMfrCodes
        {
          get { return extMfrCodes; }
        }
    }
}
