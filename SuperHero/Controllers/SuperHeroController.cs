using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SuperHero.Models;
using SuperHero.Data;

namespace SuperHero.Controllers
{
    public class PeopleController : Controller
    {
        readonly ApplicationDbContext context;

        public PeopleController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: Manager
        public ActionResult Index()
        {
            var heroes = context.People.ToList();
            return View();
        }

        // GET: Manager/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Manager/Create
        public ActionResult Create()
        {
            Person person = new Person();
            return View();
        }

        // POST: Manager/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id, SuperHeroName, AlterEgo, PrimarySuperPower, SecondarySuperPower, CatchPhrase")] Person person)
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
            return View();

            //context is the database
            //people is the table with data
            //Where is locating a specific record
            //FirstOrDefault is selecting the first superhero recod in the table

        }

        // POST: Manager/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
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
            return View();
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