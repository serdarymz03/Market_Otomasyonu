using _1_Entity;
using _2_Data_Access.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Business.Concrete
{
    public class CategoryManager
    {
        CategoryDal categoryDal;
        static CategoryManager categoryManager;
        private CategoryManager()
        {
            categoryDal = CategoryDal.GetInstance();
        }

        public string Add(Category entity)
        {
            try
            {
                if (!IsCategoryComplete(entity))
                {
                    return "Kategori Bilgileri Hatalı";
                }
                return categoryDal.Add(entity);
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
                if (entityId < 1)
                {
                    return "Kategori Bilgileri Hatalı";
                }
                return categoryDal.Delete(entityId);
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
                if (entityId < 1)
                {
                    return null;
                }
                return categoryDal.Get(entityId);
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
                return categoryDal.GetList();
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
                if (!IsCategoryComplete(entity))
                {
                    return "Kategori Bilgileri Hatalı"; ;
                }
                return categoryDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        bool IsCategoryComplete(Category category)
        {
            if (category.CategoryId < 1)
            {
                return false;
            }
            if (string.IsNullOrEmpty(category.Name) || string.IsNullOrEmpty(category.Detail))
            {
                return false;
            }
            return true;
        }

        public string GetCategoryNameById(int categoryId)
        {
            try
            {
                var categories = GetList();

                foreach (Category categoryItem in categories)
                {
                    if (categoryItem.CategoryId == categoryId)
                    {
                        return categoryItem.Name;
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public int GetCategoryIdByName(string categoryName)
        {
            try
            {
                var categories = GetList();

                foreach (Category categoryItem in categories)
                {
                    if (categoryItem.Name.ToLower().Contains(categoryName.ToLower()))
                    {
                        return categoryItem.CategoryId;
                    }
                }

                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }




        public static CategoryManager GetInstance()
        {
            if (categoryManager == null)
            {
                categoryManager = new CategoryManager();
            }
            return categoryManager;
        }
    }
}
