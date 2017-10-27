using System.Web.Mvc;

namespace ProjetoBanco.MVC.Controllers
{
    public class testeController : Controller
    {
        // GET: teste
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string teste)
        {
            if (teste == null)
            {
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = 400;
                return Content("erro");
            }
            else
            {
                Response.StatusCode = 200;
                return Content("OK");
            }
        }
    }
}