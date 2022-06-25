using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppDB.Data;
using WebAppDB.Models;

namespace WebAppDB.Controllers
{
    public class LanguageController : Controller
    {
        //Create Interface object
        readonly ILanguageRepo _languageService;
        //DI context
        private readonly MyDbContext _context;

        //DI interface
        public LanguageController(ILanguageRepo languageService, MyDbContext context)
        {
            _languageService = languageService;

            //DI context
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_languageService.Read());
        }

        [HttpGet]//View Form page
        public IActionResult Create()
        {
            //City city = new City();
            // return View(city);
            return View();
        }
        [HttpPost]//Send Data to server via form
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind(" LanguageID, LanguageName")] Language city)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(student);
                // await _context.SaveChangesAsync();
                _languageService.Create(city);
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }

        //Edit
        public IActionResult Edit(int id)

        {
            if (id == 0)
            {
                return NotFound();
            }

            var city = _languageService.Read(id);
            if (city == null)
            {
                return NotFound();
            }
            return View(city);

        }

        [HttpPost]//Send Data to server via form
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind(" LanguageID, LanguageName")] Language city)//ID should be same in Entity
        {
            if (id != city.LanguageID)//
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //_context.Add(student);
                // await _context.SaveChangesAsync();
                // _cityService.Create(city);
                _languageService.Update(city);
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }

        //Delete get
        public IActionResult Delete(int id)

        {
            if (id == 0)
            {
                return NotFound();
            }

            var city = _languageService.Read(id);
            if (city == null)
            {
                return NotFound();
            }
            return View(city);

        }


        // POST: Country/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var city = _languageService.Read(id);
            _languageService.Delete(city);
            return RedirectToAction(nameof(Index));
        }

        //Language person extra

        public IActionResult Index2(int id)
        {
            var person= _context.Pepoles
                                   .Where(s => s.Id == id)
                                      .ToList();
            foreach (Person  per in person)
            {
                ViewBag.Msg = per.FirstName+" "+per.LastName;
            }
            return View(_languageService.Read());
        }

        public IActionResult Add(int id)
        {
           
            //
            var perso = _context.Languages
                                  .Where(s => s.LanguageID == id)
                                     .ToList();
            foreach (Language per in perso)
            {
                ViewBag.Languge = per.LanguageName;
            }
            //
            var city = _languageService.Read(id);
            _languageService.Delete(city);
            return RedirectToAction(nameof(Index2));
        }

        public IActionResult Edit2(int id)
        {
            //ViewBag.Msg = "Hellow Esam";
             //
             /*
             var perso = _context.Languages
                                  .Where(s => s.LanguageID == id)
                                     .ToList();

            if (perso != null) { ViewBag.Msg = "List Languge is not empty"; }

          


            foreach (Language per in perso)
            {
                ViewBag.Languge = per.LanguageName;
            }*/
           
            return View(_languageService.Read());
        }


        }//End class



}
