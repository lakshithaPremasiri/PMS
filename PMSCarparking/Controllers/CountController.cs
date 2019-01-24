using PMSCarparking.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO.Ports;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMSCarparking.Controllers
{
    public class CountController : Controller
    {
        PMSEntities context = new PMSEntities();
        // GET: Count
        public ActionResult Count()
        {
            try
            {

                //string parkIDNew = "Par183429073432";
                string parkIDNew = "Par185306015326";

                parking objParking = context.parkings.Where(o => o.parking_id == parkIDNew).FirstOrDefault();
                int? slot =   objParking.parking_available_slots;
                int? slt = objParking.slots;
                string price = objParking.price_per_day;

            //    context.Entry(objParking).State = EntityState.Added;
                return View(objParking);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
    }
}