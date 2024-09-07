using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PSS_08_1.Models;
using PSS_08_1.Models.ViwModel;
namespace PSS_08_1.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Query()
        {
            List<QueryViwModels> list = null; 

            using (DBMVCEntities db = new DBMVCEntities())
            {
                list = (from d in db.C_User
                        where d.C_STATUS == 1 
                        orderby d.EMAIL 
                        select new QueryViwModels
                            {
                            _Edad = d.EDAD,
                            
                            _Email = d.EMAIL,
                            
                            _Id = d.ID
                            
                            }
                        ).ToList();
            }

            return View();
        }
    }
}