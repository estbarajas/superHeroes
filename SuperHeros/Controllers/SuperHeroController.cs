
using SuperHeros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperHeros.Controllers
{
    public class SuperHeroController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        
        public ActionResult Index()
        {

            return View(db.SuperHeroe.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,AlterEgo,PrimaryAbility,SecondaryAbility,CatchPhrase")]SuperHero superHero)
        {
            if (ModelState.IsValid)
            {
                db.SuperHeroe.Add(superHero);
                db.SaveChanges();
                RedirectToAction("Index");

            }
            return View();
        }
    }
}