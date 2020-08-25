using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Data_Access.Abstract
{
    interface IDatabase
    {
        DbCommand Execute(params DbParameter[] parameters);
      
        DbDataReader GetList(params DbParameter[] parameters);

        DataTable GetTable(params DbParameter[] parameters);

        //Şu anlık fazla örnek vermiyorum. Sql Kullanımını Öğrendikten Sonra Detaylı Şekilde Kullanıyor Olacağız Zaten
    }
}
