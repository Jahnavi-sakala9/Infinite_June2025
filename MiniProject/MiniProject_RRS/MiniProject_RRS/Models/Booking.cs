using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_RRS
{
    public class Booking 
    { 
        public int BookingId; public int UserId; 
        public int TrainId; public string ClassCode = "";
        public int Qty; public DateTime TravelDate; 
        public decimal TotalCost; 
        public bool IsCancelled; 
    }
}
