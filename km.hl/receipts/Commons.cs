using System;
using System.Collections.Generic;
using System.Text;

namespace km.hl.receipts {
    class Commons {
        public static bool checkSerialIsItemCode(String serial) {
            foreach (orm.OrderItem item in ((orm.OrderItem.IOrderItemMapper)km.hl.orm.OrmContext.Instance.getMapper(typeof(orm.OrderItem))).getItemsByIntCode(serial)) {
                return true;
            };
            foreach (orm.OrderItem item in ((orm.OrderItem.IOrderItemMapper)km.hl.orm.OrmContext.Instance.getMapper(typeof(orm.OrderItem))).getItemsByMfrCode(serial)) {
                return true;
            };
            return false;
        }

        public static bool checkSerialBySerial(String serial) {
            foreach (orm.OrderItemSerial item in ((orm.OrderItemSerial.IOrdersItemsSerialsMapper)km.hl.orm.OrmContext.Instance.getMapper(typeof(orm.OrderItemSerial))).getSerialsBySerial(serial)) {
                return true;
            };
            return false;
        }
    }
}
