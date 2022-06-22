using Data_Access_Layer.Repository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business_Layer
{
    public class EmployeeService: IEmployeeService
    {

        private readonly IRepository<Employee> _employee;
        Employee employeeobj = new Employee();

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

                employeeobj.Exception= "Internal Server Error - Class:EmployeeService and Method: public Employee GetEmployeeById(int EmployeeId) " + ex.InnerException + "-" + ex.Message + "-" + ex.StackTrace;
                return employeeobj;
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

                employeeobj.Exception = "Internal Server Error - Class:EmployeeService and Method:  public IEnumerable<Employee> GetAllEmployees() " + ex.InnerException + " - " + ex.Message + "-" + ex.StackTrace;
                List<Employee> list = new List<Employee>();
                list.Add(employeeobj);
                return list;
            }
            
        }


        public void AddEmployee(Employee objEmployee)
        {
            try
            {
                _employee.Create(objEmployee);
            }
            catch (Exception ex)
            {

                employeeobj.Exception = "Internal Server Error - Class:EmployeeService and Method: public void AddEmployee(Employee objEmployee) " + ex.InnerException + " - " + ex.Message + "-" + ex.StackTrace;

            }
            
        }

        public void DeleteEmployeeById(Employee ObjEmployee)
        {
            try
            {
                _employee.Delete(ObjEmployee);
            }
            catch (Exception ex)
            {

                employeeobj.Exception = "Internal Server Error - Class:EmployeeService and Method: public void DeleteEmployeeById(Employee ObjEmployee)" + ex.InnerException + " - " + ex.Message + "-" + ex.StackTrace;
            }
           
                

        }

    }
}
