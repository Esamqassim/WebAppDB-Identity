using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppDB.Models;

namespace WebAppDB.Controllers
{
    public class CityesController : Controller
    {
        //Create Interface object
        readonly ICityRepo  _cityService;

        //DI interface
        public CityesController(ICityRepo cityService)
        {
            _cityService = cityService; 
        }
        public IActionResult Index()
        {
            return View(_cityService.Read());//return all db list
           // return View();
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
        public IActionResult Create([Bind("ID,CityName, CountryName")] City city)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(student);
                // await _context.SaveChangesAsync();
                _cityService.Create(city);
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

            var city = _cityService.Read(id);
            if (city == null)
            {
                return NotFound();
            }
            return View(city);
            
        }
        [HttpPost]//Send Data to server via form
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("CityID,CityName, CountryName")] City city)//ID should be same in Entity
        {
            if (id != city.CityID)//
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //_context.Add(student);
                // await _context.SaveChangesAsync();
                // _cityService.Create(city);
                _cityService.Update(city);
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

            var city = _cityService.Read(id);
            if (city == null)
            {
                return NotFound();
            }
            return View(city);

        }

        // POST: City/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult  DeleteConfirmed(int id)
        {
            var city = _cityService.Read(id);
            _cityService.Delete(city);
            return RedirectToAction(nameof(Index));
        }




    }
}
