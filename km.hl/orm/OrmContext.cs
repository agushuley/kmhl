using System;
using System.Collections.Generic;
using System.Text;

using km.hl.outturn.orm;
using km.hl.receipts.orm;

namespace km.hl.orm {
    public class OrmContext : g.orm.impl.GenericContext {
        private OrmContext() {
            this.registerMapper(typeof(MoveOrder), typeof(MoveOrdersMapper));
            this.registerMapper(typeof(Buyer), typeof(BuyersMapper));
            this.registerMapper(typeof(MoveOrderItem), typeof(MoveOrdersItemsMapper));
            this.registerMapper(typeof(ItemSerial), typeof(ItemsSerialsMapper));

            // Purhaise orders
            this.registerMapper(typeof(Order), typeof(OrdersMapper));
            this.registerMapper(typeof(OrderItem), typeof(OrdersItemsMapper));
            this.registerMapper(typeof(OrderItemSerial), typeof(OrderItemSerialMapper));
        }

        static g.orm.ORMContext ctx = new OrmContext();
        public static g.orm.ORMContext Instance {
            get { return ctx; }
        }
    }
}
