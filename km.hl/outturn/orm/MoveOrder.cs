using System;
using System.Collections.Generic;
using System.Text;

using g.orm.impl;
using g.orm;

namespace km.hl.outturn.orm {
    public enum MoveOrderSate { U, C, G }
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
            set { checkRo("state"); state = value; }
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

        private Buyer buyer;
        public Buyer Buyer {
            get { return buyer; }
            set { checkRo("buyer"); buyer = value; }
        }

        private bool complete = false;

        public bool Complete {
            get { return complete; }
            set { complete = value; markDirty(); }
        }
    }
}
