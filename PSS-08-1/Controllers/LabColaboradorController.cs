using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PSS_08_1.Models;
using PSS_08_1.Models.ViwModel;
namespace PSS_08_1.Controllers
{
    public class LabColaboradorController : Controller
    {
        // GET: LabColaborador
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult LabQuery() {
			List<LabColaboradorQueryViwModels> list = null;

			using (DBMVCEntities db = new DBMVCEntities())
            {
                list = (from lab in db.LABCOLABORADORES
                        where lab.ESTATUS == 1
                        orderby lab.REGISTRADO
                        select new LabColaboradorQueryViwModels {

                            LabColaborador_ID = lab.COLABORADOR_ID,
                            Nombre_Colaborador = lab.NOMBRE_COLABORADOR,
                            Departamento_Colaborador = lab.DEPARTAMENTO,
                            Registrado_Colaborador = lab.REGISTRADO
                        
                        }).ToList();

            }

                return View(list);
        }
    }
}