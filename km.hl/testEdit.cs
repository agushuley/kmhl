using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using km.hl.orm;
using g.orm;

namespace km.hl {
    public partial class testEdit : Form {
        public testEdit()
        {
            InitializeComponent();
        }

        private void testEdit_Load(object sender, EventArgs e)
        {
            this.comboBox1.DataSource = new MoveOrderSate[]{MoveOrderSate.Y, MoveOrderSate.N};
            foreach (MoveOrder order in orm.Context.Instance.getMapper(typeof(MoveOrder)).getAll()) {
                orders.Add(order);
            }
            this.ordersBindingSource.DataSource = orders;
            this.textBox1.DataBindings.Add("Text", ordersBindingSource, "State");
        }

        void orders_AddingNew(object sender, AddingNewEventArgs e) {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            orm.Context.Instance.commit();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ordersBindingSource.MovePrevious();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.ordersBindingSource.EndEdit();
            this.ordersBindingSource.MoveNext();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.ordersBindingSource.EndEdit();
            this.ordersBindingSource.AddNew();
        }

        private void component1BindingSource_CurrentChanged(object sender, EventArgs e) {

        }

        BindingList<MoveOrder> orders = new BindingList<MoveOrder>();

        private void ordersBindingSource_AddingNew(object sender, AddingNewEventArgs e) {
            try {
                orm.Context.Instance.getMapper(typeof(MoveOrder)).add(order);
                e.NewObject = order;
            }
            catch (Exception ex) {
                orders.CancelNew(orders.Count - 1);
                throw new ORMException("Duplicate key");
            }
        }

        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e) {

        }

        private void ordersBindingSource_CurrentChanged(object sender, EventArgs e) {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }
        
    }
}