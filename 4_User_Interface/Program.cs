using _1_Entity;
using _3_Business.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_User_Interface
{
    class Program
    {
        static ProductManager productManager;
        static CategoryManager categoryManager;
        static List<Product> products;
        static List<Category> categories;
        static string userName, userChoise;
        static Product chosenProduct;

        static void Init()
        {
            productManager = ProductManager.GetInstance();
            categoryManager = CategoryManager.GetInstance();
            userName = ""; userChoise = "";
        }
        static void ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Sayın {0}, Seçiminizi Yapınız", GetUserName());
            Console.WriteLine();
            Console.WriteLine("Ana Menü");
            Console.WriteLine("1 - Tüm Ürünleri Listele");
            Console.WriteLine("2 - İsme Göre Ürünü Getir ve Seç");
            Console.WriteLine("3 - Kategoriye Göre Ürün Getir");
            Console.WriteLine("4 - Kategorileri Listele");
            Console.WriteLine("5 - Yeni Ürün Ekle");
            Console.WriteLine("6 - Seçilen Ürünü Güncelle");
            Console.WriteLine("7 - Seçilen Ürünü Sil");
            Console.WriteLine("8 - Yeni Kategori Ekle");
            Console.WriteLine();
            Console.WriteLine("0 - Çıkmak İçin Sıfıra Basınız");
            Console.WriteLine();
        }
        static string GetUserName()
        {
            string firstLetter = userName.Substring(0, 1);
            firstLetter = firstLetter.ToUpper();

            userName = firstLetter + userName.Substring(1);
            return userName;
        }
        static void Main(string[] args)
        {
            Init();

            Console.WriteLine("HOŞGELDİNİZ");

            while (userName.Length < 3)
            {
                Console.Write("İsminizi Giriniz: ");
                userName = Console.ReadLine();
            }

            while (userChoise != "0")
            {
                ShowMenu();
                Console.Write("Seçiminiz : ");
                userChoise = Console.ReadLine();

                switch (userChoise)
                {
                    case "1":
                        GetProductList();
                        break;
                    case "2":
                        GetProductByName();
                        break;
                    case "3":
                        GetProductByCategory();
                        break;
                    case "4":
                        CategoryList();
                        break;
                    case "5":
                        AddProduct();
                        break;
                    case "6":
                        UpdateProduct();
                        break;
                    case "7":
                        DeleteProduct();
                        break;
                    case "8":
                        AddCategory();
                        break;
                    case "0":
                        break;

                    default:
                        Console.WriteLine("Hatalı Seçim");
                        break;
                }

            }




            Console.WriteLine("İyi Günler Dileriz");
            Console.ReadLine();
        }

        private static void AddCategory()
        {
            Console.Write("Id : ");
            int categoryId = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Category Name : ");
            string categoryName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Category Detail : ");
            string categoryDetail = Console.ReadLine();
            Console.WriteLine();

            Category category = new Category(categoryId, categoryName, categoryDetail);

            if (AreYouSure())
            {
                Console.WriteLine(categoryManager.Add(category));
            }
        }

        private static void DeleteProduct()
        {
            if (chosenProduct == null)
            {
                Console.WriteLine("Öncelikle Ürün Seçiniz");
                return;
            }

            if (AreYouSure())
            {
                Console.WriteLine(productManager.Delete(chosenProduct.ProductId));
            }
        }

        private static void UpdateProduct()
        {
            if (chosenProduct == null)
            {
                Console.WriteLine("Öncelikle Ürün Seçiniz");
                return;
            }

            Console.Write("Product Name : ");
            string productName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Category Name : ");
            string categoryName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Quantity : ");
            int quantity = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Product Price : ");
            double price = double.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Supplier Id: ");
            int supplierId = int.Parse(Console.ReadLine());
            Console.WriteLine();

            int categoryId = categoryManager.GetCategoryIdByName(categoryName);
            if (categoryId < 1)
            {
                Console.WriteLine("Kategori Bilgisi Hatalı");
                return;
            }

            Product product = new Product(chosenProduct.ProductId, productName, categoryId, quantity, price, supplierId);

            Console.WriteLine("Güncelleme Yapmak İstediğinize Emin Misiniz? y/n");
            string userLetter = Console.ReadLine();
            while (1 == 1)
            {
                if (userLetter.ToLower() == "y")
                {
                    Console.WriteLine(productManager.Update(product));
                    break;
                }
                else if (userLetter.ToLower() == "n")
                {
                    return;
                }
                Console.WriteLine("Hatalı Bir Tuşlama Yaptınız. Tekrar Deneyiniz. y/n");
                userLetter = Console.ReadLine();
            }

        }

        private static void AddProduct()
        {
            Console.Write("Id : ");
            int productId = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Product Name : ");
            string productName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Category Name : ");
            string categoryName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Quantity : ");
            int quantity = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Product Price : ");
            double price = double.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Supplier Id: ");
            int supplierId = int.Parse(Console.ReadLine());
            Console.WriteLine();

            int categoryId = categoryManager.GetCategoryIdByName(categoryName);
            if (categoryId < 1)
            {
                Console.WriteLine("Kategori Bilgisi Hatalı");
                return;
            }

            Product product = new Product(productId, productName, categoryId, quantity, price, supplierId);
            Console.WriteLine(productManager.Add(product));
        }

        private static void CategoryList()
        {
            categories = categoryManager.GetList();
            foreach (Category item in categories)
            {
                Console.WriteLine($"Id : {item.CategoryId}, Name : {item.Name}, Detail : {item.Detail} ");
            }
        }

        private static void GetProductByCategory()
        {
            Console.Write("Kategori İsmini Yazınız : ");
            string categoryName = Console.ReadLine();

            int categoryId = categoryManager.GetCategoryIdByName(categoryName);

            products = productManager.GetList();

            foreach (Product item in products)
            {
                if (item.CategoryId == categoryId)
                {
                    Console.WriteLine($" Id : {item.ProductId} Name : {item.Name} Category Name : {categoryManager.GetCategoryNameById(item.CategoryId)} Quantity : {item.Quantity} Price : {item.Price}  Supplier Id : {item.SupplierId}");
                    break;
                }
            }
        }

        private static void GetProductByName()
        {
            Console.Write("Seçmek İstediğiniz Ürünün İsmini Giriniz: ");
            string productName = Console.ReadLine();

            products = productManager.GetList();


            foreach (Product item in products)
            {
                if (item.Name.ToLower().Contains(productName.ToLower()))
                {
                    chosenProduct = item;
                    Console.WriteLine($" Id : {item.ProductId} Name : {item.Name} Category Name : {categoryManager.GetCategoryNameById(item.CategoryId)} Quantity : {item.Quantity} Price : {item.Price}  Supplier Id : {item.SupplierId}");
                    break;
                }
            }
        }

        private static void GetProductList()
        {
            products = productManager.GetList();

            foreach (Product item in products)
            {
                categories = categoryManager.GetList();

                string categoryName = "";

                foreach (Category categoryItem in categories)
                {
                    if (categoryItem.CategoryId == item.CategoryId)
                    {
                        categoryName = categoryItem.Name;
                        break;
                    }
                }
                Console.WriteLine("Id : {0} Name : {1} Category : {2} Quantity : {3} Unit Price : {4} Supplier : {5}", item.ProductId, item.Name, categoryName, item.Quantity, item.Price, item.SupplierId);
            }
        }

        static bool AreYouSure()
        {
            Console.WriteLine("Emin Misiniz? y/n");
            string userLetter = Console.ReadLine();
            while (1 == 1)
            {
                if (userLetter.ToLower() == "y")
                {
                    return true;
                }
                else if (userLetter.ToLower() == "n")
                {
                    return false;
                }
                Console.WriteLine("Hatalı Bir Tuşlama Yaptınız. Tekrar Deneyiniz. y/n");
                userLetter = Console.ReadLine();
            }
        }

    }
}
