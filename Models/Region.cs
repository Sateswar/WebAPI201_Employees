using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI201.Employees.Models
{
    [Table("regions", Schema = "WebAPI")]

    public class Region
    {
        public int Id { get; set; }
        public int Name { get; set; }
    }
}
