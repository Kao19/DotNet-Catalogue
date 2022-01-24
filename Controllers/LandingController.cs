using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tshirt.Context;
using System.Data.SqlClient;

namespace Tshirt.Controllers
{
    public class LandingController : Controller
    {
        // GET: Landing

        testdbEntities dbObj = new testdbEntities();

        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        void connectionString()
        {
            con.ConnectionString = "data source=DESKTOP-DM9PGQP\\MSSQLSERVER01; database=testdb; integrated security = SSPI";
        }

        public ActionResult Landing()
        {
            return View(dbObj.tableTshirt.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
