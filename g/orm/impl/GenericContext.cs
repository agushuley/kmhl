using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace g.orm.impl {
    public abstract class GenericContext : ORMContext {
	    private IDictionary<String, IDbConnection> cnns = 
            new Dictionary<String, IDbConnection>();
        private IDictionary<String, IDbTransaction> transacts =
            new Dictionary<String, IDbTransaction>();
        private IDictionary<String, DataFactory> factories =
            new Dictionary<String, DataFactory>();
	    private IDictionary<Type, Type> mappersForClasses = 
            new Dictionary<Type, Type>();
        private IDictionary<Type, Mapper> mappers =
            new Dictionary<Type, Mapper>();

	    public void registerMapper(Type domObjClall, Type mapperType) {
		    mappersForClasses.Add(domObjClall, mapperType);
	    }
    	
	    public IDbConnection getConnection(String key) {
            lock (this) {
                if (cnns.ContainsKey(key)) {
                    return cnns[key];
                }
                try {
                    IDbConnection cnn = getFactory(key).getConnection(g.config.Config.get(key + ".connection"));
                    cnn.Open();
                    cnns.Add(key, cnn);
                    return cnn;
                }
                catch (DataException ex) {
                    throw new ORMException(ex);
                }

            }
        }

        public IDbTransaction getTransaction(String key) {
            lock (this) {
                if (transacts.ContainsKey(key)) {
                    return transacts[key];
                }
                try {
                    IDbTransaction tr = getFactory(key).getTransaction(getConnection(key));
                    transacts.Add(key, tr);
                    return tr;
                }
                catch (DataException ex) {
                    throw new ORMException(ex);
                }
            }
        }

        public DataFactory getFactory(String key) {
            lock (this) {
                if (factories.ContainsKey(key)) {
                    return factories[key];
                }
                DataFactory factory = Class.CreateInstance<DataFactory>(g.config.Config.get(key + ".factory"));
                factories.Add(key, factory);
                return factory;
            }
        }

        public Mapper getMapper(Type type) {
            Type o = type;

            while (type != typeof(Object)) {
                if (mappersForClasses.ContainsKey(type)) {
                    return getHashMapper(mappersForClasses[type]);
                }
                type = type.BaseType;
            }

            throw new ORMException("Can't find mapper for class " + type.FullName);
        }

        private Mapper getHashMapper(Type mapperType) {
            lock (this) {
                if (mappers.ContainsKey(mapperType)) {
                    return (Mapper)mappers[mapperType];
                }
                Mapper mapper = (Mapper)Activator.CreateInstance(mapperType);
                mapper.Context = this;
                mappers.Add(mapperType, (Mapper)mapper);
                return mapper;
            }
        }

        public void update() {
		    foreach (Type key in mappers.Keys) {
			    mappers[key].commit();
                mappers[key].setClean();
		    }
	    }

        public void commit() {
		    update();
		    foreach (IDbTransaction trans in transacts.Values) {
			    try {
				    trans.Commit();
			    } catch (DataException e) {
				    throw new ORMException(e);
			    }
		    }
	    }

        public void close() {
            rollback();
            foreach (IDbConnection conn in cnns.Values) {
                try {
                    conn.Close();
                    conn.Dispose();
                }
                catch (DataException e) {
                    throw new ORMException(e);
                }
            }
            cnns.Clear();

            foreach (Mapper mapper in mappers.Values) {
                mapper.clear();
            }
	    }

        public void rollback() {
            foreach (IDbTransaction trans in transacts.Values) {
                try {
                    trans.Rollback();
                }
                catch (DataException e) {
                    throw new ORMException(e);
                }
            }
            transacts.Clear();
        }
        #region IDisposable Members

        public void Dispose() {
            close();
        }

        #endregion
    }
}
