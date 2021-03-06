﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace g.orm.impl {
    public abstract class AbstractSqlMapper : Mapper {
        public interface IRowFilter {
            bool test(DataRow row);
        }

        private IDictionary<Key, ORMObject> registry = new Dictionary<Key, ORMObject>();

        private ORMContext ctx = null;
        protected ORMContext Ctx {
            get { return ctx; }
        }

	    public void clear() { registry.Clear(); }
    	
	    protected abstract String ConnectionKey { get; }
    	
	    protected IDbConnection getConnection(bool mutable) {
            return ctx.getConnection(ConnectionKey, mutable); 
	    }

        protected void releaseConnection(IDbConnection cnn, IDbTransaction tran) {
            ctx.releaseConnection(cnn, tran);
        }

        public IDictionary<Key, ORMObject> Registry {
            get { return registry; }
	    }

	    public ORMObject loadObject(DataRow rs) {
		    Key key = createKey(rs);
		    lock (registry) {
                if (registry.ContainsKey(key)) {
                    return registry[key];
                }
			    ORMObject obj = createInstance(key, rs);
			    obj.ORMState = StateType.LOADING;
			    registry.Add(obj.ORMKey, obj);
			    try {
				    loadInstance(obj, rs);
				    obj.ORMState = StateType.CLEAN;
			    }
			    catch (ORMException e) {
				    registry.Remove(obj.ORMKey);
				    throw e;
			    }
			    catch (Exception e) {
                    registry.Remove(obj.ORMKey);
				    throw new ORMException(e);
			    }
			    return obj;
		    }
	    }
    	
	    protected abstract void loadInstance(ORMObject obj, DataRow rs);
	    protected abstract ORMObject createInstance(Key key, DataRow rs);

	    public ORMObject this[Key id] {
            get {
		        lock (registry) {
			        if (registry.ContainsKey(id)) {
				        return registry[id];
			        }			

		            try {
                        ICollection<ORMObject> c = getObjectsForCb(getSelectByKeyCb(id));
                        IEnumerator<ORMObject> e = c.GetEnumerator();
                        if (e.MoveNext()) {
                            return e.Current;
                        }
                        return null;
		            } catch (DataException e) {
			            throw new ORMException(e);
		            }
                }
            }
	    }

        public ORMObject[] getAll() {
            lock (registry) {
                try {
                    getObjectsForCb(getSelectAllCb());
                    ORMObject[] o = new ORMObject[Registry.Count];
                    Registry.Values.CopyTo(o, 0);
                    return o;
                }
                catch (DataException e) {
                    throw new ORMException(e);
                }
            }
	    }

        abstract protected GetQueryCallback getSelectAllCb();
        abstract protected GetQueryCallback getSelectByKeyCb(g.orm.Key key);

	    abstract protected GetQueryCallback getInsertQueryCB();
	    abstract protected GetQueryCallback getUpdateQueryCB();
	    abstract protected GetQueryCallback getDeleteQueryCB();

        delegate GetQueryCallback QueryCallbackDelegate();
	    public void commit() {
		    try {
			    executeBatchForObjects(getInsertQueryCB, StateType.NEW);
			    executeBatchForObjects(getDeleteQueryCB, StateType.DELETED);
			    executeBatchForObjects(getUpdateQueryCB, StateType.DIRTY);
		    } catch (DataException e) {
			    throw new ORMException(e);
		    }		
	    }
    	
	    public void setClean() {
            IList<ORMObject> removed = new List<ORMObject>(); 
		    foreach (ORMObject obj in Registry.Values) {
			    if (obj.ORMState == StateType.DELETED) {
                    removed.Add(obj);
			    }
                obj.ORMState = StateType.CLEAN;
		    }
            foreach (ORMObject obj in removed) {
                Registry.Remove(obj.ORMKey);
            }
	    }
    	
        
	    private void executeBatchForObjects(QueryCallbackDelegate queryCB, StateType state) {
		    IDbCommand stm = null;
            IDbConnection cnn = null;
            IDbTransaction trans = null;
		    try {
			    foreach (ORMObject obj in Registry.Values) {
				    if (obj.ORMState == state) {
					    if (stm == null) {
                            cnn = getConnection(true);
                            trans = ctx.getTransaction(ConnectionKey);
						    stm = ctx.getFactory(ConnectionKey).getCommand(cnn, trans);
                            stm.CommandText = queryCB().Sql;
					    }
					    queryCB().SetParams(stm, obj);
					    stm.ExecuteNonQuery();
				    }
			    }			
		    }
		    finally {
			    if (stm != null) {
				    stm.Dispose();
                    releaseConnection(cnn, trans);
			    }
		    } 
	    }

        protected ORMObject[] getObjectsForCb(GetQueryCallback cb) {
            return getObjectsForCb(cb, null);
        }

        protected ORMObject[] getObjectsForCb(GetQueryCallback cb, AbstractSqlMapper.IRowFilter filter) {
            lock (registry) {
                IDbConnection cnn = getConnection(false);
                IDbTransaction trans = ctx.getTransaction(ConnectionKey);
                try {
                    using (IDbCommand cmd = ctx.getFactory(ConnectionKey).getCommand(cnn, trans)) {
                        cmd.CommandText = cb.Sql;
                        cb.SetParams(cmd, null);
                        IDbDataAdapter adapter = ctx.getFactory(ConnectionKey).getAdapter(cmd);
                        DataSet set = new DataSet();
                        adapter.Fill(set);

                        List<ORMObject> list = new List<ORMObject>();
                        foreach (DataRow row in set.Tables["Table"].Rows) {
                            if (filter == null || filter.test(row)) {
                                list.Add(loadObject(row));
                            }
                        }
                        ORMObject[] o = new ORMObject[list.Count];
                        list.CopyTo(o);
                        return o;
                    }
                }
                catch (DataException e) {
                    throw new ORMException(e);
                }
                finally {
                    releaseConnection(cnn, trans);
                }
            }
        }
    	
	    public void add(ORMObject obj) {
		    lock (registry) {
                if (this[obj.ORMKey] != null) {
				    throw new ORMException("Duplicate object key");
			    }
			    registry.Add(obj.ORMKey, obj);
			    obj.ORMState = StateType.NEW;
		    }		
	    }

        #region Mapper<ORMObject,Key> Members

        public abstract Key createKey(DataRow rs);
        public abstract Key createKey();

        public ORMContext Context {
            set { ctx = value; }
            get { return ctx; }
        }

        #endregion
    }
}
