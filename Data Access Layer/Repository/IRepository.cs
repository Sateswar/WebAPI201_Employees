using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository
{
    public interface IRepository<T>
    {
        public T GetById(int Id);
        public IEnumerable<T> GetAll();
        public Task<T> Create(T _object);
        public void Delete(T _object);
        public void Update(T _object);
    }
}
