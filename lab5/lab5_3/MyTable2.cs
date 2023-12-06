using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lab5_3
{
    public partial class MyTable2
    {
        [Key]
        public int Table_id { get; set; }

        public string Some_add_info { get; set; }

        public virtual MyTable MyTable { get; set; }
    }
    
}
