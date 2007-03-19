using System;
using System.Collections.Generic;
using System.Text;
using km.hl.outturn.orm;

namespace km.hl.orm {
    public class OrmContext : g.orm.impl.GenericContext {
        private OrmContext() {
            this.registerMapper(typeof(MoveOrder), typeof(MoveOrdersMapper));
            this.registerMapper(typeof(Buyer), typeof(BuyersMapper));
            this.registerMapper(typeof(MoveOrderItem), typeof(MoveOrdersItemsMapper));
            this.registerMapper(typeof(ItemSerial), typeof(ItemsSerialsMapper));
        }

        static g.orm.ORMContext ctx = new OrmContext();
        public static g.orm.ORMContext Instance {
            get { return ctx; }
        }
    }
}
