using System;
using System.Collections.Generic;
using System.Text;

namespace km.hl.dom {
    public class Context : g.orm.impl.GenericContext {
        private Context() {
            this.registerMapper(typeof(junius.Order), typeof(junius.OrderMapper));
            this.registerMapper(typeof(junius.OrderDetail), typeof(junius.OrderDetailsMapper));
        }

        static g.orm.ORMContext ctx = new Context();
        public static g.orm.ORMContext Instance {
            get { return ctx; }
        }
    }
}
