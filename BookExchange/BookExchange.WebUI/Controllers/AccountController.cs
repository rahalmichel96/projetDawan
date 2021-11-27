using BookExchange.Core.Models;
using BookExchange.DataAccess.SQL;
using BookExchange.DataAccess.SQL.Metier;
using BookExchange.WebUI.Exceptions;
using BookExchange.WebUI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BookExchange.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private IRepository<Utilisateur> utilisateurDao;
        private IUtilisateurService userService;
        private IUtilisateurRepository userCustomRepository;

        public AccountController()
        {
            utilisateurDao = new SQLRepository<Utilisateur>(new MyContext());
            userCustomRepository = new UtilisateurRepository(new MyContext());
            userService = new UtilisateurService(utilisateurDao, userCustomRepository);
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Utilisateur u)
        {
            if (ModelState.IsValid)
            {
                if (u.Password.Equals(u.ConfirmPWD))
                {
                    Utilisateur user = new Utilisateur(u.Nom, u.Prenom, u.Ville, u.Username, u.Password, u.ConfirmPWD, u.Email, TypeUtilisateur.CLIENT);
                    try
                    {
                        userService.InsertUser(user);  //Ajoute l'entité u au contexte
                    }
                    catch (UsernameException eUserName)
                    {
                        ViewBag.ExceptionUserName = eUserName.Message;
                        return View();
                    }
                    catch (EmailException eUserName)
                    {
                        ViewBag.EmailException = eUserName.Message;
                        return View();
                    }

                    userService.SaveChanges();  //Ensuite l'ajoute dans la base de données

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.Clear();
                    ViewBag.ErrorLog = "Les deux mots de passe ne correspondant pas";
                    return View();
                }
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(String email, string password)
        {
            if (ModelState.IsValid)
            {
                Utilisateur u = userService.CheckLogin(email, password);
                if (u == null)
                {
                    ModelState.Clear();
                    ViewBag.ErrorLog = "L'adresse renseignée n'existe pas ou le mot de passe est faux";
                    return View();
                }
                else
                {
                    //Connexion a reussi
                    Session["Connexion"] = u.Username;
                    Session["TypeUtilisateur"] = u.TypeUtilisateur;
                    Session["Email"] = u.Email;
                    Session["Id"] = u.Id;

                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewBag.ErrorLog = "Le pseudo ou le mot de passe ne sont pas renseignés";
                return View();
            }
        }

        public ActionResult LogOut()
        {
            Session["Connexion"] = null;
            Session["TypeUtilisateur"] = null;
            Session["Email"] = null;
            Session["Id"] = null;

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Utilisateur utilisateur = userService.FindById((int)id);

            if (utilisateur == null)
            {
                return HttpNotFound();
            }

            return View(utilisateur);

        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateur utilisateur = userService.FindById((int)id);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }

            return View(utilisateur);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Utilisateur user, HttpPostedFileBase photo)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            else
            {
                userService.Update(user);
                userService.SaveChanges();

                return RedirectToAction("Details", new { Id = user.Id });
                //return RedirectToAction("Index");
            }
        }
    }
}