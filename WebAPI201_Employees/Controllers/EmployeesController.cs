using Business_Layer;
using Data_Access_Layer.Repository;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;
using System;
using System.Text.Json;

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
        public IActionResult GetEmployeeById(int id)
        {
            try
            {
                Employee emp = new Employee();
                emp = _employeeService.GetEmployeeById(id);
                if (emp == null)
                {
                    return NotFound();
                }
                return Ok(_employeeService.GetEmployeeById(id));
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal Server Error - Class:EmployeesController and Method: public IActionResult GetEmployeeById(int id)" + ex.InnerException + "-" + ex.Message + "-" + ex.StackTrace);
            }

        }


        // GET: api/<Employees>
        [HttpGet("GetEmployees")]
        public IActionResult GetAllEmployees()
        {
            try
            {
                return Ok(_employeeService.GetAllEmployees());
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal Server Error in - Class:EmployeesController and Method: public IActionResult GetAllEmployees() " + ex.InnerException + "-" + ex.Message + "-" + ex.StackTrace);
            }

        }

        // POST api/<Employees>
        [HttpPost("AddEmployee")]
        public IActionResult AddEmployee([FromBody] JsonDocument value)
        {
            try
            {
                string json = System.Text.Json.JsonSerializer.Serialize(value);
                Employee emp = JsonConvert.DeserializeObject<Employee>(json);
                _employeeService.AddEmployee(emp);
                return Created("~api/Employees/AddEmployee", emp);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal Server Error  - Class:EmployeesController and Method: public IActionResult AddEmployee([FromBody] JsonDocument value)" + ex.InnerException + "-" + ex.Message + "-" + ex.StackTrace);
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
                if (emp == null)
                {
                    return NotFound();
                }
                emp.Id = EmployeeId;
                _employeeService.DeleteEmployeeById(emp);

            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal Server Error  - Class:EmployeesController and Method: public ActionResult DeleteEmployeeByEmployeeId(int EmployeeId) " + ex.InnerException + "-" + ex.Message + "-" + ex.StackTrace);
            }
            return Ok();

        }
    }
}
