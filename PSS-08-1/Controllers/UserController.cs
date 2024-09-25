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
		public ActionResult Query() {
			List<QueryViwModels> list = null;

			using (DBMVCEntities db = new DBMVCEntities())
			{
				list = (from d in db.C_User
						where d.C_STATUS == 1
						orderby d.EMAIL
						select new QueryViwModels {
							_Edad = d.EDAD,

							_Email = d.EMAIL,

							_Id = d.ID

						}
						).ToList();
			}

			return View(list);
		}

		public ActionResult Add() {


			return View();
		}

		[HttpPost]
		public ActionResult Add( AddUserViewModel aUser ) {

			if (!ModelState.IsValid)
			{
				return View();
			}

			using (DBMVCEntities db = new DBMVCEntities())
			{
				C_User oUser = new C_User();
				oUser.C_STATUS = 1;
				oUser.EMAIL = aUser._Email;
				oUser.NOMBRE = aUser._Nombre;
				oUser.EDAD = aUser._Edad;
				oUser.PASSWORD = aUser._Password;
				db.C_User.Add(oUser);
				db.SaveChanges();
			}

			return Redirect(Url.Content("~/User/Query"));
		}
	}
}