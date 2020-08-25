using _2_Data_Access.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Data_Access.Database
{
    public class Oracle : IDatabase
    {
        public DbCommand Execute(params DbParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public DbDataReader GetList(params DbParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public DataTable GetTable(params DbParameter[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}
