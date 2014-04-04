using System;
using System.Collections.Generic;
using System.Text;

using g.orm.impl;

namespace km.hl.outturn.orm {
    public class ItemSerial : GenericORMObject {
        public ItemSerial(ItemSerialKey key) : base(key) { }
        public ItemSerial(MoveOrderItem item, String serial) : base(new ItemSerialKey(item.Id, serial)) {
            this.item = item;
        }

        public String Serial {
            get { return ((ItemSerialKey)ORMKey).Serial; }
        }

        private MoveOrderItem item;
        public MoveOrderItem Item {
          get { return item; }
          set { checkRo("item"); item = value; }
        }
    }
}
