using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Entity
{
    public class Category
    {
        int categoryId;
        string name, detail;

        public int CategoryId { get => categoryId; set => categoryId = value; }
        public string Name { get => name; set => name = value; }
        public string Detail { get => detail; set => detail = value; }

        public Category(int categoryId, string name, string detail)
        {
            this.categoryId = categoryId;
            this.name = name;
            this.detail = detail;
        }
    }
}
