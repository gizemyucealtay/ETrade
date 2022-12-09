using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Core
{
    public interface IBaseRepository<T> where T : class
    {
        public List<T> List();
        public T Find(int Id);
        public T Find(int Id,int Id2); //composite key için ayrı bir method oluşturduk find ve delete de hata veriyo çünkü find ve delete i normal Id için yazmıştık
        public T Find(string Id);
        public bool Update(T entity);
        public bool Delete(int Id);
        public bool Delete(int Id,int Id2);
        public bool Delete(string Id);
        public bool Add(T entity);
        public DbSet<T> Set();
    }
}
