using System;
using System.Collections.Generic;
using System.Text;

namespace test {
    public enum Yn { Y, N };
    class Program {
        static void Main(string[] args) {
            System.Console.WriteLine("Not null: " + g.DbTools.ToEnum<Yn>(DBNull.Value));
            System.Console.WriteLine("Null " + g.DbTools.ToEnum<Yn?>(DBNull.Value));
            System.Console.WriteLine("Not null: " + g.DbTools.ToEnum<Yn>("Y"));
            System.Console.WriteLine("Null " + g.DbTools.ToEnum<Yn?>("N"));
        }
    }
}
