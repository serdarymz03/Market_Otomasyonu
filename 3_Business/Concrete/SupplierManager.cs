using _1_Entity;
using _2_Data_Access.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Business.Concrete
{
    public class SupplierManager
    {
        SupplierDal supplierDal;

        public SupplierManager()
        {
            supplierDal = SupplierDal.GetInstance();
        }

        public string Add(Supplier entity)
        {
            try
            {
                if (!IsSupplierComplete(entity))
                {
                    return "Hatalı Tedarikçi Bilgisi";
                }
                return supplierDal.Add(entity);
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
                    return "Hatalı Tedarikçi Bilgisi";
                }
                return supplierDal.Delete(entityId);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Supplier Get(int entityId)
        {
            try
            {
                if (entityId < 1)
                {
                    return null;
                }
                return supplierDal.Get(entityId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Supplier> GetList()
        {
            try
            {
                return supplierDal.GetList();
            }
            catch (Exception)
            {

                return new List<Supplier>();
            }
        }

        public string Update(Supplier entity)
        {
            try
            {
                if (!IsSupplierComplete(entity))
                {
                    return "Hatalı Tedarikçi Bilgisi";
                }
                return supplierDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        bool IsSupplierComplete(Supplier supplier)
        {
            if (supplier.SupplierId < 1)
            {
                return false;
            }
            if (string.IsNullOrEmpty(supplier.Name) || string.IsNullOrEmpty(supplier.Contact))
            {
                return false;
            }
            return true;
        }
    }
}
