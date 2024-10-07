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

		[HttpGet]
		public ActionResult Edit(int id) {
			EditUserViewModel model = new EditUserViewModel();

			using (var db = new DBMVCEntities()) {

				var oUser = db.C_User.FirstOrDefault(sf => sf.ID == id);

				model._Edad = oUser.EDAD;
				model._Nombre = oUser.NOMBRE;
				model._Email = oUser.EMAIL;
				model._Password = oUser.PASSWORD;
				model._IDUser = oUser.ID;
				return View(model);
			}

			
		}

		[HttpPost]
		public ActionResult Edit(EditUserViewModel model) {

			using (var db = new DBMVCEntities()) {
				var eUser = db.C_User.FirstOrDefault(sf => sf.ID == model._IDUser);

				if (eUser != null) {
					eUser.NOMBRE = model._Nombre;
					eUser.EMAIL = model._Email;
					eUser.EDAD = model._Edad;


					if (model._Password != null || model._Password != "")
					{
						eUser.PASSWORD = model._Password;
					}

					db.Entry(eUser).State = System.Data.Entity.EntityState.Modified;

					db.SaveChanges();
				}
				


			}

			return Redirect(Url.Content("~/User/Query"));
		}

		[HttpPost]

		public ActionResult Delete(int id) {

			using (var db = new DBMVCEntities()) {
				var dUser = db.C_User.Find(id);

				if (dUser != null) {
					dUser.C_STATUS = 3;

					db.Entry(dUser).State = System.Data.Entity.EntityState.Modified;
					db.SaveChanges();
				}
			
			}

			return Content("1");

		}
	}
}