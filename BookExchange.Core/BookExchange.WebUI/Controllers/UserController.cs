using BookExchange.Core.Models;
using BookExchange.DataAccess.SQL;
using BookExchange.DataAccess.SQL.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookExchange.WebUI.Controllers
{
    public class UserController : Controller
    {
        IRepository<Utilisateur> userDao;

        public UserController()
        {
            userDao = new SQLRepository<Utilisateur>(new MyContext());
        }

        // GET: User
        public ActionResult Index()
        {
            List<Utilisateur> users = userDao.Collection().ToList();
            return View(users);
        }

        public ActionResult Create()
        {
            return View(new Utilisateur());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Utilisateur u)
        {
            u.Commandes = new List<Commande>();
            u.Compte = new Compte();
            if (!ModelState.IsValid)
            {
                return View(u);
            }

            userDao.Insert(u);
            userDao.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}