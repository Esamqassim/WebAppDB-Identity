using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppDB.Models;

namespace WebAppDB.Controllers
{
    public class CountriesController : Controller

    {
        //Create Interface object
        readonly ICountryRepo _countryService;

        //DI interface
        public CountriesController(ICountryRepo countryService)
        {
            _countryService = countryService;
        }
        public IActionResult Index()
        {
            return View(_countryService.Read());
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
        public IActionResult Create([Bind("CountryID, CountryName")] Country city)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(student);
                // await _context.SaveChangesAsync();
                _countryService.Create(city);
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

            var city = _countryService.Read(id);
            if (city == null)
            {
                return NotFound();
            }
            return View(city);

        }

        [HttpPost]//Send Data to server via form
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("CountryID, CountryName")] Country city)//ID should be same in Entity
        {
            if (id != city.CountryID)//
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //_context.Add(student);
                // await _context.SaveChangesAsync();
                // _cityService.Create(city);
                _countryService.Update(city);
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

            var city = _countryService.Read(id);
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
            var city = _countryService.Read(id);
            _countryService.Delete(city);
            return RedirectToAction(nameof(Index));
        }
    }
}
