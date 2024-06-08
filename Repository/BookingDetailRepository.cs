﻿using BussinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BookingDetailRepository
    {
        private static BookingDetailDAO bookingDetailDAO = new BookingDetailDAO();

        public static List<BookingDetail> GetAllBookingDetail()
        {
            return bookingDetailDAO.GetAllBookingDetail();
        }


    }
}
