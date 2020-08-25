using _1_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Data_Access.Concrete
{
    public class CategoryDal : IRepository<Category>
    {
        List<Category> categories;
        static CategoryDal categoryDal;
        public CategoryDal()
        {
            categories = new List<Category>();
            categories.Add(new Category(1, "Temizlik Kategorisi", "Temizlik Ürünlerini Barındıran Kategori"));
            categories.Add(new Category(2, "Konserve Kategorisi", "Konserve Ürünlerini Barındıran Kategori"));
            categories.Add(new Category(3, "Gıda", "Gıda Ürünlerini Barındıran Kategori"));
            categories.Add(new Category(4, "Bahçe Malzeme Kategorisi", "Bahçe Malzemelerini Barındıran Kategori"));
        }

        public string Add(Category entity)
        {
            try
            {
                categories.Add(entity);
                return entity.Name + " Kategorisi Başarıyla Eklendi";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(int entityId)
        {
            try
            {
                foreach (Category item in categories)
                {
                    if (item.CategoryId == entityId)
                    {
                        categories.Remove(item);
                        return item.Name + " Kategorisi Başarıyla Silindi";
                    }
                }
                return "Ürün Bulunamadı";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Category Get(int entityId)
        {
            try
            {
                foreach (Category item in categories)
                {
                    if (item.CategoryId == entityId)
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

        public List<Category> GetList()
        {
            try
            {
                return categories;
            }
            catch (Exception)
            {
                return new List<Category>();
            }
        }

        public string Update(Category entity)
        {
            try
            {
                for (int i = 0; i < categories.Count; i++)
                {
                    if (categories[i].CategoryId == entity.CategoryId)
                    {
                        categories[i] = entity;
                        return entity.Name + " Kategorisi Başarıyla Güncellendi";
                    }
                }
                return "Kategori Bulunamadı";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static CategoryDal GetInstance()
        {
            if (categoryDal == null)
            {
                categoryDal = new CategoryDal();
            }
            return categoryDal;
        }
    }
}
