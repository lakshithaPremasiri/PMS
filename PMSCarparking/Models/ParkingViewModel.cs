using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMSCarparking.Models
{
    public class ParkingViewModel
    {
        public int id { get; set; }
        public string parking_id { get; set; }
        public string parking_name { get; set; }
        public Nullable<double> parking_longitude { get; set; }
        public Nullable<double> parking_latitude { get; set; }
        public Nullable<int> parking_available_slots { get; set; }
        public Nullable<int> town_id { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
        public Nullable<int> slots { get; set; }
        public string price_per_day { get; set; }

        public virtual town town { get; set; }
    }
}