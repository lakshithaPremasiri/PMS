using PMSCarparking.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO.Ports;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.Routing;

namespace PMSCarparking
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ScheduleTaskTrigger();
        }

        static void ScheduleTaskTrigger()
        {
            HttpRuntime.Cache.Add("ScheduledTaskTrigger",
                                  string.Empty,
                                  null,
                                  Cache.NoAbsoluteExpiration,
                                  TimeSpan.FromSeconds(1), // Every 0 seconds
                                  CacheItemPriority.NotRemovable,
                                  new CacheItemRemovedCallback(PerformScheduledTasks));
        }

        static void PerformScheduledTasks(string key, Object value, CacheItemRemovedReason reason)
        {
            try
            {
                PMSEntities context = new PMSEntities();

                SerialPort Stream = new SerialPort("COM15", 9600);
                Stream.Close();
                Stream.Open();


                string parkID = Stream.ReadLine();
                string parkIDNew = parkID.Remove(parkID.Length - 1);
                System.Threading.Thread.Sleep(1000);
                string value1 = Stream.ReadLine();
                string valueNew = value1.Remove(value1.Length - 1);

                parking objParking = context.parkings.Where(o => o.parking_id == parkIDNew).FirstOrDefault();
                if (valueNew == "in")
                {
                    objParking.parking_available_slots = objParking.parking_available_slots - 1;
                }
                else
                {
                    objParking.parking_available_slots = objParking.parking_available_slots + 1;
                }
                context.Entry(objParking).State = EntityState.Modified;
                context.SaveChanges();

                //GetCount();
                Stream.Close();

                ScheduleTaskTrigger();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //void Application_Start(object sender, EventArgs e)
        //{
        //    ScheduleTaskTrigger();
        //}
    }
}
