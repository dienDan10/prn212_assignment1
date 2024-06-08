using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObjects
{
    public class BookingReservation
    {
        public int BookingReservationID { get; set; }
        public string BookingDate { get; set; }
        public decimal TotalPrice { get; set; }
        public int CustomerID { get; set; }
        public short BookingStatus { get; set; }

        public BookingReservation()
        {
            
        }
    }
}
