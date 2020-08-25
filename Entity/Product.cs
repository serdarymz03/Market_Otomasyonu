using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Product
    {
        int productId,quantity,categoryId,supplierId;
        string name;
        double price;

        public int ProductId { get => productId; set => productId = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int CategoryId { get => categoryId; set => categoryId = value; }
        public int SupplierId { get => supplierId; set => supplierId = value; }
        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
    }
}
