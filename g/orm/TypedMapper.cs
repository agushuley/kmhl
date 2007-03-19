using System;
using System.Collections.Generic;
using System.Text;

namespace g.orm {
    public class TypedMapper<T>
        where T : g.orm.ORMObject
    {
        private Mapper mapper;
        public TypedMapper(Mapper mapper) {
            this.mapper = mapper;
        }

        public T this[Key id] { 
            get { return (T)mapper[id]; } 
        }
        public T[] getAll() {
            ORMObject[] l = mapper.getAll();
            T[] o = new T[l.Length];
            l.CopyTo(o, 0);
            return o;
        }
        public void add(T obj) {
            mapper.add(obj);
        }
    }
}
