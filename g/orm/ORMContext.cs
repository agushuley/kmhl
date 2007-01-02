using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace g.orm {
    public interface ORMContext : IDisposable {
        Mapper getMapper(Type type);
        void commit();
        void close();
        void rollback();
        void update();

        DataFactory getFactory(String key);
        IDbConnection getConnection(String key);
        IDbTransaction getTransaction(String key);
    }
}
