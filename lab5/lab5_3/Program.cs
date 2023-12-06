
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static lab5_3.Program;

namespace lab5_3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            using (Model1Container db = new Model1Container())
            {
                MyTable myTable1 = new MyTable { Table_id = 1, Some_info = "something" };
                MyTable myTable2 = new MyTable { Table_id = 2, Some_info = "something else" };

                db.MyTable.Add(myTable1);
                db.MyTable.Add(myTable2);
                db.SaveChanges();
                Console.WriteLine("Об'єкти успішно додано");

                var tables = db.MyTable;
                Console.WriteLine("Список об'єктів:");
                foreach (MyTable t in tables)
                {
                    Console.WriteLine("{0}.{1}", t.Table_id, t.Some_info);
                }
            }
            Console.Read();

        }
    }
}
