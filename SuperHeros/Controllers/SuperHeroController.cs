
using SuperHeros.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public ActionResult Details(int id = 0)
        {
            SuperHero superHero = db.SuperHeroe.Find(id);
            return View(superHero);
        }
        public ActionResult Edit(int id)
        {
            SuperHero superHero = db.SuperHeroe.Find(id);
            return View(superHero);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,AlterEgo,PrimaryAbility,SecondaryAbility,CatchPhrase")] SuperHero superHero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(superHero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(superHero);
        }
    }
}