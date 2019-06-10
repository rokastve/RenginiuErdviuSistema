using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projektas.Models
{
    public class DataView
    {
        public List<Reservation> userReservationList { get; set; }
        public int reservationCode { get; set; }
        public FoodOrder model { get; set; }
        public UserOrder userOrderModel { get; set; }
        public IEnumerable<SelectListItem> reservationIds { get; set; }


        public DataView()
        {
            this.userReservationList = new List<Reservation>();
            this.userOrderModel = new UserOrder();
            this.model = new FoodOrder();
        }
    }
}