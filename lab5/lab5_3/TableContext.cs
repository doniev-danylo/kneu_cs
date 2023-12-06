using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static lab5_3.MyTable;

namespace lab5_3
{
    public partial class Model1Container : DbContext
    {
        public Model1Container()
            : base("name=DBConnection")
        {
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //   throw new UnintentionalCodeFirstException();
        //}

        public DbSet<MyTable> MyTable { get; set; }
        public DbSet<MyTable2> MyTable2 { get; set; }
    }
}
