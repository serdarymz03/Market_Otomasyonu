using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Entity
{
    public class Transfer
    {
        int transferId;
        DateTime orderDate, shipmentDate;
        double shipmentPrice;

        public int TransferId { get => transferId; set => transferId = value; }
        public DateTime OrderDate { get => orderDate; set => orderDate = value; }
        public DateTime ShipmentDate { get => shipmentDate; set => shipmentDate = value; }
        public double ShipmentPrice { get => shipmentPrice; set => shipmentPrice = value; }

        public Transfer(int transferId, DateTime orderDate, DateTime shipmentDate, double shipmentPrice)
        {
            this.transferId = transferId;
            this.orderDate = orderDate;
            this.shipmentDate = shipmentDate;
            this.shipmentPrice = shipmentPrice;
        }
    }
}
