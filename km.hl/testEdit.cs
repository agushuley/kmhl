using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using km.hl.dom.hl;
using g.orm;

namespace km.hl {
    public partial class testEdit : Form {
        public testEdit()
        {
            InitializeComponent();
        }

        private void testEdit_Load(object sender, EventArgs e)
        {
            this.ordersBindingSource.DataSource = orders;
            foreach (MoveOrder order in dom.Context.Instance.getMapper(typeof(MoveOrder)).getAll()) {
                orders.Add(order);
            }
            orders.AllowNew = true;
            orders.AddingNew += new AddingNewEventHandler(orders_AddingNew);
        }

        void orders_AddingNew(object sender, AddingNewEventArgs e) {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dom.Context.Instance.commit();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ordersBindingSource.MovePrevious();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.ordersBindingSource.MoveNext();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.ordersBindingSource.AddNew();
        }

        private void component1BindingSource_CurrentChanged(object sender, EventArgs e) {

        }

        BindingList<MoveOrder> orders = new BindingList<MoveOrder>();

        private void ordersBindingSource_AddingNew(object sender, AddingNewEventArgs e) {
            try {
                MoveOrder order = new MoveOrder(new g.orm.impl.IntKey(10));
                dom.Context.Instance.getMapper(typeof(MoveOrder)).add(order);
                e.NewObject = order;
            }
            catch (Exception ex) {
                orders.CancelNew(orders.Count - 1);
                throw new ORMException("Duplicate key");
            }
        }

        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e) {

        }
        
    }
}