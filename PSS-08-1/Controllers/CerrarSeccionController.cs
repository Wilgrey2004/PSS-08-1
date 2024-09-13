using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PSS_08_1.Controllers
{
    public class CerrarSeccionController : Controller
    {
        
        public ActionResult Logoff() {

            Session["Usuario"] = null;
            return RedirectToAction("Loging","Acceder");//Redirecciona al Loging...
        
        }
    }
}