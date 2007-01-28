using System;
using System.Collections.Generic;
using System.Text;

namespace km.hl.orm {
    public class Context : g.orm.impl.GenericContext {
        private Context() {
            this.registerMapper(typeof(MoveOrder), typeof(MoveOrdersMapper));
            this.registerMapper(typeof(Buyer), typeof(BuyersMapper));
            this.registerMapper(typeof(MoveOrderItem), typeof(MoveOrdersItemsMapper));
            this.registerMapper(typeof(ItemSerial), typeof(ItemsSerialsMapper));
        }

        static g.orm.ORMContext ctx = new Context();
        public static g.orm.ORMContext Instance {
            get { return ctx; }
        }
    }
}
