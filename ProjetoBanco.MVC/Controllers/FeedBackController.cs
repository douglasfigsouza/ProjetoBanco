﻿using System.Web.Mvc;
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
    }
}