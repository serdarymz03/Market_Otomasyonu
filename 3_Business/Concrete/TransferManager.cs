using _1_Entity;
using _2_Data_Access.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Business.Concrete
{
    public class TransferManager
    {
        TransferDal transferDal;

        public TransferManager()
        {
            transferDal = TransferDal.GetInstance();
        }
        public string Add(Transfer entity)
        {
            try
            {
                if (!IsTransferComplete(entity))
                {
                    return "Hatalı Transfer Bilgisi";
                }
                return transferDal.Add(entity);
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
                    return "Hatalı Transfer Bilgisi";
                }
                return transferDal.Delete(entityId);
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
                if (entityId < 1)
                {
                    return null;
                }
                return transferDal.Get(entityId);
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
                return transferDal.GetList(); ;
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
                if (!IsTransferComplete(entity))
                {
                    return "Hatalı Transfer Bilgisi";
                }
                return transferDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        bool IsTransferComplete(Transfer transfer)
        {
            if (transfer.TransferId < 1)
            {
                return false;
            }
            if (transfer.OrderDate == null || transfer.ShipmentDate == null)
            {
                return false;
            }
            if (transfer.ShipmentPrice < 0)
            {
                return false;
            }
            return true;
        }
    }
}
