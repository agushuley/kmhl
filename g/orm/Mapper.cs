using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace g.orm {
    public interface Mapper {
	    Key createKey(DataRow rs);
	    Key createKey();
	    ORMContext Context{ set; }
	    void clear();
        IDbConnection Connection { get; }
        IDictionary<Key, ORMObject> Registry { get; }
	    ORMObject this[Key id] { get; }
	    ORMObject[] getAll();
	    void add(ORMObject obj);
	    void commit();
	    void setClean(); 
    }
}
