using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMSCarparking.Models
{
    public class TownViewModel
    {
        public int id { get; set; }
        public string town_id { get; set; }
        public Nullable<double> town_longitude { get; set; }
        public Nullable<double> town_latitude { get; set; }
        public string town_name { get; set; }
    }
}