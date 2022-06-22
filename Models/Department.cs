using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("departments", Schema = "WebAPI")]
    public class Department
    {
        public int Id { get; set; }
        public string departmentName { get; set; }
    }
}
