using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI201.Employees.Models;

namespace Models
{
    [Table("Employees", Schema = "WebAPI")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public DateTime? HireDate { get; set; }
        public decimal? salary { get; set; }
        public int? JobId { get; set; }
        [ForeignKey("JobId")]
        public ICollection<Job> Jobs { get; set; }
        public int? DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public ICollection<Department> Department { get; set; }
        public int? ManagerId { get; set; }
        [ForeignKey("ManagerId")]
        public ICollection<Employee> Manager { get; set; }

    }
}
