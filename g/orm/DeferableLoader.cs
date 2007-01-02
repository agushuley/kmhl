using System;
using System.Collections.Generic;
using System.Text;

namespace g.orm {
    public interface DeferableLoader<T, K>
        where T : ORMObject
        where K : ORMObject
    {
        ICollection<T> load(K obj);
    }
}
