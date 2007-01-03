using System;
using System.Collections.Generic;
using System.Text;

namespace km.hl.dom {
    public class Context : g.orm.impl.GenericContext {
        public Context() {
            this.registerMapper(typeof(junius.Order), typeof(junius.OrderMapper));
            this.registerMapper(typeof(junius.OrderDetail), typeof(junius.OrderDetailsMapper));
        }
    }
}
