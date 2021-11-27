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
    public class UtilisateurController : Controller
    {
        IRepository<Utilisateur> utilisateurDao;

        public UtilisateurController()
        {
            this.utilisateurDao = new SQLRepository<Utilisateur>(new MyContext());
        }


        // GET: Utilisateur
        public ActionResult Index()
        {
            List<Utilisateur> utilisateurs = utilisateurDao.Collection().ToList();
            return View(utilisateurs);
        }

        // GET: Utilisateur/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Utilisateur/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Utilisateur/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Utilisateur/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Utilisateur/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Utilisateur/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Utilisateur/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
