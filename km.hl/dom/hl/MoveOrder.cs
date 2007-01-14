using System;
using System.Collections.Generic;
using System.Text;
using g.orm.impl;

namespace km.hl.dom.hl {
    public class MoveOrder : AbstractORMObject {
        public MoveOrder(g.orm.impl.IntKey key) : base(key) { }

        String description;

        public String Description {
            get { return description; }
            set { description = value; }
        }
    }
}
