using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI201.Employees.Models
{
    [Table("countries", Schema = "WebAPI")]

    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
