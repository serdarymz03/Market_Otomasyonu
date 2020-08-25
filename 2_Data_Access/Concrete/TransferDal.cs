using _1_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Data_Access.Concrete
{
    public class TransferDal : IRepository<Transfer>
    {
        List<Transfer> transfers;
        static TransferDal transferDal;

        public TransferDal()
        {
            transfers = new List<Transfer>();
            transfers.Add(new Transfer(1, new DateTime(2020, 1, 1), new DateTime(2020, 2, 2), 1500));
            transfers.Add(new Transfer(2, new DateTime(2020, 3, 15), new DateTime(2020, 4, 15), 1900));
            transfers.Add(new Transfer(3, new DateTime(2020, 5, 21), new DateTime(2020, 6, 27), 150));
            transfers.Add(new Transfer(4, new DateTime(2020, 6, 6), new DateTime(2020, 7, 2), 25000));
        }
        public string Add(Transfer entity)
        {
            try
            {
                transfers.Add(entity);
                return "Kayıt Başarıyla Eklendi";
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
                foreach (Transfer item in transfers)
                {
                    if (item.TransferId == entityId)
                    {
                        transfers.Remove(item);
                        return "Kayıt Başarıyla Kaldırıldı";
                    }
                }
                return "Kayıt Bulunamadı";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Transfer Get(int entityId)
        {
            try
            {
                foreach (Transfer item in transfers)
                {
                    if (item.TransferId == entityId)
                    {
                        return item;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Transfer> GetList()
        {
            try
            {
                return transfers;
            }
            catch (Exception)
            {

                return new List<Transfer>();
            }
        }

        public string Update(Transfer entity)
        {
            try
            {
                for (int i = 0; i < transfers.Count; i++)
                {
                    if (transfers[i].TransferId == entity.TransferId)
                    {
                        transfers[i] = entity;
                        return " Kayıt Başarıyla Güncellendi";
                    }
                }
                return "Kayıt Bulunamadı";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static TransferDal GetInstance()
        {
            if (transferDal == null)
            {
                transferDal = new TransferDal();
            }
            return transferDal;
        }
    }
}
