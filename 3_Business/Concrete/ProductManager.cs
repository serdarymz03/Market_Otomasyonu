using _1_Entity;
using _2_Data_Access.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Business.Concrete
{
    public class ProductManager
    {
        ProductDal productDal;
        static ProductManager productManager;
        private ProductManager()
        {
            productDal = ProductDal.GetInstance();
        }

        public List<Product> GetList()
        {
            try
            {
                return productDal.GetList();
            }
            catch (Exception ex)
            {
                return new List<Product>();
            }
        }

        public Product Get(int productId)
        {
            try
            {
                if (productId < 1)
                {
                    return null;
                }
                return productDal.Get(productId);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string Add(Product entity)
        {
            try
            {
                if (!IsProductComplete(entity))
                {
                    return "Ürün Bilgileri Hatalı";
                }
                return productDal.Add(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public string Update(Product entity)
        {
            try
            {
                if (!IsProductComplete(entity))
                {
                    return "Ürün Bilgileri Hatalı";
                }
                return productDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(int productId)
        {
            try
            {
                if (productId < 1)
                {
                    return "Silmek İstediğiniz Ürünü Seçiniz";
                }
                return productDal.Delete(productId);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        bool IsProductComplete(Product product)
        {
            if (product.ProductId < 1)
            {
                return false;
            }
            if (string.IsNullOrEmpty(product.Name.Trim()))
            {
                return false;
            }
            if (product.CategoryId < 1 || product.SupplierId < 1 || product.Price < 0 || product.Quantity < 1)
            {
                return false;
            }
            return true;
        }

        public static ProductManager GetInstance()
        {
            if (productManager == null)
            {
                productManager = new ProductManager();
            }
            return productManager;
        }
    }
}
