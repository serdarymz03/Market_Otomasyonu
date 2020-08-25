using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Data_Access
{
    interface IRepository<T>
    {
        List<T> GetList();
        T Get(int entityId);
        string Add(T entity);
        string Update(T entity);
        string Delete(int entityId);

    }
}
