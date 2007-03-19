using System;
using System.Collections.Generic;
using System.Text;

using g.orm.impl;

namespace km.hl.orm {
    public class Buyer : GenericORMObject {
        public Buyer(IntKey key) : base(key) { }

        private String description;
        public String Description {
            get { return description; }
            set { checkRo("description"); description = value; }
        }

        public int Id {
            get { return ((IntKey)ORMKey).Int;}
        }
    }
}
