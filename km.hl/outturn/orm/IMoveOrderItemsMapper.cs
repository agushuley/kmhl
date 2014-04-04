using System;
using System.Collections.Generic;
using System.Text;

namespace km.hl.outturn.orm {
    public interface IMoveOrderItemsMapper : g.orm.Mapper {
        ICollection<MoveOrderItem> getItemsForOrder(MoveOrder obj);
        ICollection<MoveOrderItem> getItemsForMfrCode(String mfrCode);
        ICollection<MoveOrderItem> getItemsForInternalCode(String intCode);
    }
}
