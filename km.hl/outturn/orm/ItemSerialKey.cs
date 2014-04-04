using System;
using System.Collections.Generic;
using System.Text;

using g.orm.impl;

namespace km.hl.outturn.orm {
    public class ItemSerialKey : AbstractKey {
        public ItemSerialKey(int itemId, String serial) {
            this.itemId = itemId;
            this.serial = serial;
        }

        private int itemId;
        public int ItemId {
            get { return itemId; }
        }

        private String serial;
        public String Serial {
            get { return serial; }
        }

        public override Object[] Values {
            get { return new Object[] { itemId, serial }; }
        }
    }
}
