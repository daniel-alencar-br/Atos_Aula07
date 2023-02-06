using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Atos_Aula07.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string Teste1()
        {
            if (User.Identity.IsAuthenticated)
                return "está autenticado";
            else
                return "Cai fora, acesso negado!";
        }

        public string Teste2()
        {
            
            if (User.Identity.Name == "joao@empresa.com.br")
                return "Oi João!";
            else
                return "Cai fora, não é o João";
        }

        public string Teste3()
        {
            if (User.IsInRole("Admin"))
                return "Oi Admin!";
            else
                return "Cai fora, não é Admin";
        }

        [Authorize(Roles="members,Admin")]
        public string Teste4()
        {
            return "Oi Admin!";
        }

        }
    }


