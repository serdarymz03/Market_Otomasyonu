using _1_Entity;
using _2_Data_Access.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Data_Access.Concrete
{
    public class ProductDal : IRepository<Product>
    {
        List<Product> products;
        static ProductDal productDal;

        public ProductDal()
        {
            products = new List<Product>();

            products.Add(new Product(1, "Çamaşır Suyu", 1, 15, 10.25, 1));
            products.Add(new Product(2, "Domates", 3, 25, 5.50, 2));
            products.Add(new Product(3, "Bahçe Makası", 4, 12, 30, 3));
            products.Add(new Product(4, "Dondurulmuş Bezelye", 2, 150, 3.75, 4));
        }

        public List<Product> GetList()
        {
            try
            {
                return products;
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
                foreach (Product item in products)
                {
                    if (item.ProductId == productId)
                    {
                        return item;
                    }
                }
                return null;
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
                products.Add(entity);
                return entity.Name + " Ürünü Başarıyla Eklendi";
            }
            catch (ArgumentNullException ex)
            {
                return "Null Değer Hatası";
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
                for (int i = 0; i < products.Count; i++)
                {
                    if (products[i].ProductId==entity.ProductId)
                    {
                        products[i] = entity;
                        return entity.Name + " Ürünü Başarıyla Güncellendi";
                    }
                }

                return "Ürün Bulunamadı";
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
                foreach (Product item in products)
                {
                    if (item.ProductId == productId)
                    {
                        products.Remove(item);
                        return item.Name + " Ürünü Başarıyla Kaldırıldı";
                    }
                }
                return "Ürün Bulunamadı";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static ProductDal GetInstance()
        {
            if (productDal == null)
            {
                productDal = new ProductDal();
            }
            return productDal;
        }
    }
}
