using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tshirt.Context;
using System.Data.SqlClient;

namespace Tshirt.Controllers
{
    public class ClientController : Controller
    {
        // GET: AdminCrud

        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        testdbEntities dbObj = new testdbEntities();

        void connectionString()
        {
            con.ConnectionString = "data source=DESKTOP-DM9PGQP\\MSSQLSERVER01; database=testdb; integrated security = SSPI";
        }


        public ActionResult Client()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ClientForum(tableClient model)
        {
            tableClient obj = new tableClient();
            obj.nom = model.nom;
            obj.prenom = model.prenom;
            obj.telephone = model.telephone;
            obj.ville = model.ville;
            obj.addresse = model.addresse;
            obj.email = model.email;

            dbObj.tableClient.Add(obj);
            dbObj.SaveChanges();

            return View("Client");
        }



    }
}