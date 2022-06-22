using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI201.Employees.Models
{
    [Table("Jobs", Schema = "WebAPI")]
    public class Job
    {
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public int MinSalary { get; set; }
        public int MaxSalary { get; set; }
    }
}
