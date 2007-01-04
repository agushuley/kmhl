using System;
namespace g.orm {
    public enum StateType { NEW, DIRTY, CLEAN, LOADING, DELETED };

    public interface ORMObject {
        Key Key { get; }
        StateType ORMState { get; set; }
        void Remove();
    }
}
