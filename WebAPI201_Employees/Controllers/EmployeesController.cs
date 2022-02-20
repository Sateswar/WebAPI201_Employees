using Business_Layer;
using Data_Access_Layer.Repository;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI201_Employees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly EmployeeService _employeeService;
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeesController(EmployeeService employeeService, IRepository<Employee> employeeRepository)
        {
            _employeeService = employeeService;
            _employeeRepository = employeeRepository;
        }

        

        // GET api/<Employees>/5
        [HttpGet("GetEmployeeById/{id}")]
        public object GetEmployeeById(int id)
        {
            return _employeeService.GetEmployeeById(id);
        }

   
        // GET: api/<Employees>
        [HttpGet("GetEmployees")]
        public object GetAllEmployees()
        {
            return _employeeService.GetAllEmployees();
        }

        // POST api/<Employees>
        [HttpPost("AddEmployee")]
        public ActionResult AddEmployee([FromBody] JsonDocument value)
        {
            try
            {
                string json = System.Text.Json.JsonSerializer.Serialize(value);
                Employee emp = JsonConvert.DeserializeObject<Employee>(json);
                 _employeeService.AddEmployee(emp);
                return Ok(); ;
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal Server Error" + ex.InnerException + "-" + ex.Message + "-" + ex.StackTrace);
            }
            
            
        }


        // DELETE api/<Employees>/5
        
        [HttpDelete]
        public ActionResult DeleteEmployeeByEmployeeId(int EmployeeId)
        {
            try
            { 
                Employee emp = new Employee();
                emp = _employeeService.GetEmployeeById(EmployeeId);
                if (string.IsNullOrEmpty(emp.firstName))
                {
                    return NotFound();
                }
                emp.Id = EmployeeId;
                 _employeeService.DeleteEmployeeById(emp);
                 return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal Server Error"+ex.InnerException+"-"+ex.Message+"-"+ex.StackTrace);
            }
        }

    }
}
