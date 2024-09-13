using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PSS_08_1.Models;


namespace PSS_08_1.Controllers
{
    public class AccederController : Controller
    {
        // GET: Acceder
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Enter(string usuario, string password)
        {
            using(DBMVCEntities db = new DBMVCEntities())
            {
                var read = db.C_User.FirstOrDefault(
                                    sf => sf.EMAIL == usuario
                                    && sf.PASSWORD == password 
                                    && sf.C_STATUS == 1
                                    );
                if (read == null) {
                    return Content("A Ocurrido un Error :( ");
                }
                Session["Usuario"] = read;
                return Content("1");

            }    
            
        }


    }
}