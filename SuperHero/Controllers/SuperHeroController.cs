using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SuperHeroProj.Models;
using SuperHeroProj.Data;

namespace SuperHeroProj.Controllers
{
    public class SuperHeroController : Controller
    {
        readonly ApplicationDbContext context;

        public SuperHeroController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: Manager
        public ActionResult Index()
        {
            var heroes = context.People.ToList();
            return View(heroes);
        }

        // GET: Manager/Details/5
        public ActionResult Details(string name)
        {
            var peopleInDb = context.People.Where(s => s.SuperHeroName == name).FirstOrDefault();
            return View(peopleInDb);
        }

        // GET: Manager/Create
        public ActionResult Create()
        {
            SuperHero person = new SuperHero();
            return View(person);
        }

        // POST: Manager/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id, SuperHeroName, AlterEgo, PrimarySuperPower, SecondarySuperPower, CatchPhrase")] SuperHero person)
        {
            try
            {
                // TODO: Add insert logic here
                context.People.Add(person);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Manager/Edit/5
        public ActionResult Edit(int id)
        {
            var peopleInDb = context.People.Where(s => s.Id == id).FirstOrDefault();

            SuperHero person = null;
            foreach (SuperHero p in context.People)
            {
                person = p;
            }

            return View(person);

            //context is the database
            //people is the table with data
            //Where is locating a specific record
            //FirstOrDefault is selecting the first superhero recod in the table

        }

        // POST: Manager/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("SuperHeroName, AlterEgo, PrimarySuperPower, SecondarySuperPower, CatchPhrase")] SuperHero person)
        {
            SuperHero peopleInDb = null;
            try
            {
                // TODO: Add update logic here
                peopleInDb = context.People.Where(p => p.Id == person.Id).Single();
                context.People.Update(peopleInDb);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            

        }

        // GET: Manager/Delete/5
        public ActionResult Delete(int id)
        {
            var peopleInDb = context.People.Where(s => s.Id == id).FirstOrDefault();
            return View(peopleInDb);
        }

        // POST: Manager/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}