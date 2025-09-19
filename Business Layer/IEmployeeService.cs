using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public interface IEmployeeService
    {
        public Employee GetEmployeeById(int EmployeeId);
       
        public IEnumerable<Employee> GetAllEmployees();
        public void AddEmployee(Employee objEmployee);
        public void DeleteEmployeeById(Employee ObjEmployee);

    }
}
