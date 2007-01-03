using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using g.config;
using g;
using g.orm;
using km.hard.scan;

namespace km.hl {
    public partial class Form1 : Form {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new testEdit().Show();
        }

        private void Form1_Load(object sender, EventArgs e) {
            try {
                scanner = g.Class.CreateInstance<Scanner>(Config.get("scannerDriver", "km.casio.CasioBarScanner, km.casio"), GetType());
                scanner.Attach(this);
                scanner.Scanned += new OnScanned(scanner_Scanned);
            }
            catch (ScanException ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        void scanner_Scanned(string code) {
            textBox1.Text += code + "\n";
        }

        km.hard.scan.Scanner scanner;

        private void checkBox1_CheckStateChanged(object sender, EventArgs e) {
        }

        private void button4_Click(object sender, EventArgs e) {
            try {
/*                DataFactory f = Class.CreateInstance<DataFactory>(Config.get("dbDriver"), null);
                using (IDbConnection cnn = f.getConnection(g.config.Config.get("dbConnectionString"))) {
                    cnn.Open();
                    using (IDbTransaction transaction = f.getTransaction(cnn)) {
                        using (IDbCommand command = f.getCommand(cnn, transaction)) {
                            command.CommandText = "SELECT sysdate FROM dual";
                            IDbDataAdapter a = f.getAdapter(command);

                            DataSet s = new DataSet();
                            a.Fill(s);
                            foreach (DataRow row in s.Tables["Table"].Rows) {
                                textBox1.Text += Convert.ToDateTime(row[0]) + "\n";
                            }
                           
                        }
                        transaction.Commit();
                    }
                } */
                using (g.orm.ORMContext ctx = new dom.Context()) {
                    g.orm.Mapper m = ctx.getMapper(typeof(dom.junius.Order));
                    foreach (dom.junius.Order o in m.getAll()) {
                        textBox1.Text += ((g.orm.impl.IntKey)o.Key).Int + ":" + o.Description + ":" + o.Date + ":" + o.Name + "\r\n";
                        o.Date = DateTime.Now;
                    }
                    ctx.update();
                    ctx.rollback();
                    ctx.commit();
                };

            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}