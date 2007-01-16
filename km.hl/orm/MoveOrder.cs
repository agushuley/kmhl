using System;
using System.Collections.Generic;
using System.Text;

using g.orm.impl;

namespace km.hl.orm {
    public enum MoveOrderSate { Y, N }
    public class MoveOrder : AbstractORMObject {
        public MoveOrder(g.orm.impl.IntKey key) : base(key) { }

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
    }
}
