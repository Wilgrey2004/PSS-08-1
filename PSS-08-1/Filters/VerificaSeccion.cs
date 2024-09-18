using PSS_08_1.Controllers;
using PSS_08_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PSS_08_1.Filters
{
    public class VerificaSeccion : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var miUsuario = (C_User)HttpContext.Current.Session["Usuario"];
            
            //System.Diagnostics.Debug.WriteLine("Usuario en sesión: " + (miUsuario != null ? miUsuario.EMAIL : "Ninguno"));

            if (miUsuario == null)
            {
                if (filterContext.Controller is AccederController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Acceder/Login");
                }
            }
            else
            {
                if (filterContext.Controller is AccederController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }
            }

            base.OnActionExecuting(filterContext);
        }

    }
}