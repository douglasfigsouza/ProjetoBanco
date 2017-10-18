using System.Web.Mvc;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.MVC.ViewModels;

namespace ProjetoBanco.MVC.Controllers
{
    public class FeedBackController : Controller
    {
        // GET: Success
        public ActionResult Success()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
        public ActionResult feedBackOperacao(feedBackViewModel feed)
        {
            if (feed.error==null)
            {
                TempData["outraOp"] = feed.url;
                TempData["menssagem"] = feed.op+": " + feed.descricao + " cadastrado com sucesso!";
                return RedirectToAction("Success", "FeedBack");
            }
            else
            {
                
                return RedirectToAction("Error", "FeedBack", feed);
            }
        }

    }
}