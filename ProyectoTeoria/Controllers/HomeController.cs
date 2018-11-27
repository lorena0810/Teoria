using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace ProyectoTeoria.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult validarUrl() {
            string url = Request.Form["url"];
            string expresion = @"(http|ftp|https)://([\w-]+\.)+(/[\w- ./?%&=]*)?";


            if (url == null || url == "")
            {
                ViewBag.Mensaje2 = "El url " + url + " es invalido ";
            }
            else {

                Regex oRegExp = new Regex(@"(http|ftp|https)://([\w-]+\.)+(/[\w- ./?%&=]*)?", RegexOptions.IgnoreCase);
                if (oRegExp.Match(url).Success) { // verific si se cumple con la exprecion regular .success devuelve un valor booleano verdadero es valido
                    ViewBag.Mensaje2 = "El url " + url + " es valido ";
                }
                else {
                    ViewBag.Mensaje2 = "El url " + url + " es invalido"; ;
                }
            }

            
            // Retornamos la vista desde la que se hizo la peticion
            return View("Index");

        }

        [HttpPost] 
        public ActionResult validarEmail()
        {
            
            string email = Request.Form["email"];
            


            // Como validar un correo
            //expresion regular para validar correo

            String expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";


            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    ViewBag.Mensaje = "El Email " + email + " es valido";
                }
                else
                {
                    ViewBag.Mensaje = "El Email " + email + " es invalido";
                }
            }
            else
            {
                ViewBag.Mensaje = "El Email " + email + " es invalido";
            }

            // Retornamos la vista desde la que se hizo la peticion
            return View("Index");

        }
    }
}