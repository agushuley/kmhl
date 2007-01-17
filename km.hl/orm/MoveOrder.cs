using System;
using System.Collections.Generic;
using System.Text;

using g.orm.impl;
using g.orm;

namespace km.hl.orm {
    public enum MoveOrderSate { Y, N }
    public class MoveOrder : GenericORMObject {
        public MoveOrder(g.orm.impl.IntKey key, DefferableLoader<MoveOrderItem, MoveOrder> itemsLoader) : base(key) {
            loader = itemsLoader;
        }

        String description;

        public String Description {
            get { return description; }
            set {
                checkRo("Description");
                description = value; 
            }
        }

        public int Id {
            get {
                return ((IntKey)ORMKey).Int;
            }
        }

        private MoveOrderSate state;
        public MoveOrderSate State {
            get { return state; }
            set { state = value; markDirty(); }
        }    

        private DateTime creationDate;
        public DateTime CreationDate {
            get { return creationDate; }
            set {
                checkRo("creationDate");
                creationDate = value; 
            }
        }

        private String number;
        public String Number {
            get { return number; }
            set {
                checkRo("number");
                number = value; 
            }
        }

        private DateTime? moveDate;
        public DateTime? MoveDate {
            get { return moveDate; }
            set {
                checkRo("moveDate");
                moveDate = value; 
            }
        }

        private DefferableLoader<MoveOrderItem, MoveOrder> loader = null;
        private ICollection<MoveOrderItem> items = null;
        public ICollection<MoveOrderItem> Items {
            get {
                if (items == null && loader != null) {
                    items = loader.load(this);
                    if (items != null) {
                        loader = null;
                    }
                }
                return items;
            }
        }
    }
}
