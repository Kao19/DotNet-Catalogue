using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Mvc;
using Tshirt.Models;

namespace Tshirt.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        void connectionString()
        {
            con.ConnectionString = "data source=DESKTOP-DM9PGQP\\MSSQLSERVER01; database=testdb; integrated security = SSPI";
        }

        [HttpPost]
        public ActionResult Verify(Account acc)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from tableAdmin where Login='"+acc.Login+"' and Password='"+acc.Password+"'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("Create");
            }
            else
            {
                con.Close();
                return View("Login");
            }
            
            
        }
    }
}