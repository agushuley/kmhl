using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using g.orm;
using km.hl.dom.junius;

namespace ITScan
{
    public partial class Component1 : Component
    {
        public Component1()
        {
            InitializeComponent();
        }

        public Component1(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public Order[] Orders {
            get {
                return new TypedMapper<Order>(km.hl.dom.Context.Instance.getMapper(typeof(Order))).getAll(); ;
            }
        }
    }
}
