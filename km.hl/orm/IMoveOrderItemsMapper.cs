using System;
using System.Collections.Generic;
using System.Text;

namespace km.hl.orm {
    public interface IMoveOrderItemsMapper : g.orm.Mapper {
        ICollection<MoveOrderItem> getItemsForOrder(MoveOrder obj);
    }
}
