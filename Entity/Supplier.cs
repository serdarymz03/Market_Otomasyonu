using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Supplier
    {
        int supplierId;
        string name, contact;

        public int SupplierId { get => supplierId; set => supplierId = value; }
        public string Name { get => name; set => name = value; }
        public string Contact { get => contact; set => contact = value; }
    }
}
