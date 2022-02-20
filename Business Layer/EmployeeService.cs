using Data_Access_Layer.Repository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class EmployeeService
    {

        private readonly IRepository<Employee> _employee;

        public EmployeeService(IRepository<Employee> employee)
        {
            _employee = employee;
        }

        //Get Employee Details By Employee Id

        public Employee GetEmployeeById(int EmployeeId)
        {
            try
            {
                return _employee.GetAll().Where(e => e.Id == EmployeeId).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        //GET All Employee Details 
        public IEnumerable<Employee> GetAllEmployees()
        {
            try
            {
                return _employee.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void AddEmployee(Employee objEmployee)
        {
            
            
              _employee.Create(objEmployee);
        }

        public void DeleteEmployeeById(Employee ObjEmployee)
        {
            try
            {
                _employee.Delete(ObjEmployee);
            }
            catch (Exception DelEx)
            {

                throw DelEx;
            }
             
        }

    }
}
