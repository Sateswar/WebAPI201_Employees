using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("departments", Schema = "WebAPI")]
    public class Department
    {
        public int Id { get; set; }
        public string departmentName { get; set; }
    }
}
