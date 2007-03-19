using System;
using System.Collections.Generic;
using System.Text;

namespace km.hl.outturn.orm {
    public interface IItemsSerialsMapper : g.orm.Mapper {
        ICollection<ItemSerial> getSerialsForItem(MoveOrderItem obj);
        ICollection<ItemSerial> getSerialsForSerial(String serialCode);
    }
}
