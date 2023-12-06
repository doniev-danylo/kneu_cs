using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lab5_3
{
    public partial class MyTable
    {
        public MyTable()
        {
            this.MyTable2 = new HashSet<MyTable2>();
        }

        [Key]
        public int Table_id { get; set; }

        public string Some_info { get; set; }

        public virtual ICollection<MyTable2> MyTable2 { get; set; }
    }
    
}
