using Data_Access_Layer.Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository
{
    public class RepositoryEmployee : IRepository<Employee>
    {
        EmployeeDBContext _dbContext;

        public RepositoryEmployee(EmployeeDBContext dBContext)
        {
            _dbContext = dBContext;
        }


       public Employee GetById(int Id)
        {
            try
            {
                return _dbContext.Employees.Where(e => e.Id == Id).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public IEnumerable<Employee> GetAll()
        {
            try
            {
                return _dbContext.Employees;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


       public async Task<Employee> Create(Employee _object)
        {
            var obj = await _dbContext.Employees.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        void IRepository<Employee>.Delete(Employee _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }



        void IRepository<Employee>.Update(Employee _object)
        {
            throw new NotImplementedException();
        }
    }
}
