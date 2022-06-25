using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppDB.Data;
using WebAppDB.Models;

namespace WebAppDB.Controllers
{
   
    public class PeoplesController : Controller
    {
        
        //Create Interface object
      readonly  IPeopleService peopleService;//Used also in part#4 &5
        //Create Interface object for person
        readonly IPeopleRepo personService;//Part#4, this is will make change context throgh
                                           //DatabasePepleRepo , this Interface will invoke all InMemoryPeopleRepo methds

        //DI contxt part#/

        private readonly MyDbContext _context;
        public PeoplesController(IPeopleService peopleService2, IPeopleRepo personService2, MyDbContext context)
        {
            peopleService = new PeopleService();//Is that correct?
            //
           // personService = new InMemoryPeopleRepo();//Do not used yet!
               
            peopleService= peopleService2; //Is it work?What is benfit?

            //Part#5

            personService = personService2;

            //Part#7
            _context = context;
        }
        /*Part#7*/

       
        public IActionResult Index2()
        {
            // return View(peopleService.All());
            return View(personService.Read());

        }
       
        [HttpGet]//View Form page
        public IActionResult Create2()
        {
            //City city = new City();
            // return View(city);
            return View();
        }
       
        [HttpPost]//Send Data to server via form
        [ValidateAntiForgeryToken]
        public IActionResult Create2([Bind(" Id,FirstName, LastName,PhoneNumber,CityName ,CityID")] Person per)
        {
            //
            var contryget = _context.Cities.
                            Where(s => s.CityName == per.CityName)
                            .ToList();

           
                foreach (City city in contryget)
                {
                if (city.CountryName != null)
                {
                    per.CountryName = city.CountryName;
                    
                }
                else
                {
                    ViewBag.Msg = "The City is not availbel i Db , Add City & Country , then Create a person ";
                    return RedirectToAction(nameof(Index2));
                }
                }
               
                  


           if (ModelState.IsValid)
            {
               
                personService.Create(per);
                ViewBag.Msg = "Successfully add Person";
                return RedirectToAction(nameof(Index2));
            }
            return View(per);
        }


        //Edit
       
        public IActionResult Edit2(int id)

        {
            if (id == 0)
            {
                return NotFound();
            }

            var city = personService.Read(id);
            if (city == null)
            {
                return NotFound();
            }
            return View(city);

        }
       
        [HttpPost]//Send Data to server via form
        [ValidateAntiForgeryToken]
        public IActionResult Edit2(int id, [Bind(" Id,FirstName, LastName,PhoneNumber,CityName ,CityID")] Person per)//ID should be same in Entity
        {
            if (id !=per.Id)//
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //_context.Add(student);
                // await _context.SaveChangesAsync();
                // _cityService.Create(city);
                personService.Update(per);
                return RedirectToAction(nameof(Index2));
            }
            return View(per);
        }

        //Delete get
        public IActionResult Delete2(int id)

        {
            if (id == 0)
            {
                return NotFound();
            }

            var city = personService.Read(id);
            if (city == null)
            {
                return NotFound();
            }
            return View(city);

        }


        // POST: Country/Delete/5
        [HttpPost, ActionName("Delete2")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var city = personService.Read(id);
            personService.Delete(city);
            return RedirectToAction(nameof(Index2));
        }

        // GET: Students/Details/5
        public IActionResult Details2(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var city = personService.Read(id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }


        /*Part#1,2,3,4,5,6****************************************************************************/
        public IActionResult Index()
        {
            // return View(peopleService.All());
            return View(personService.Read());
            
        }

        //create

        [HttpGet]//Action for page <Form> which it is Create page
        public IActionResult Create()
        {
            CreatePersonViewModel create = new CreatePersonViewModel();
            return View(create);
        }

        [HttpPost]//Action for <Form> to send information

        public IActionResult Create(
            [Bind("Id,LastName,FirstName,PhoneNumber,CityName")] Person person)
        {
            if (ModelState.IsValid)//if input data to form ok 
            {
               // peopleService.PersonAdd(create);
                personService.Create(person);
                return RedirectToAction("Index");//return to DataBase page
            }



            return View(person);

        }

        //DetailsOne
        [HttpGet] //<form> view
        public IActionResult DetailsOne(string Id)//search methd should be same like this!return view model
        {
            int result = Int32.Parse(Id);

            return View(peopleService.FindById(result));
        }

        [HttpPost, ActionName("DetailsOne")]//get id from <Form> to server
        [ValidateAntiForgeryToken]
        public IActionResult DetailsPost(int Id)//search methd should be same like this!return view model
        {
           // int result = Int32.Parse(Id);

            return View(personService.Read(Id));
            //return View(peopleService.FindById(@per.Id));
        }


        //DeleteOne <Form> View page
        [HttpGet]
        public IActionResult DeleteOne(string Id)//index file
        {

            int result = Int32.Parse(Id);
            Person delete = peopleService.FindById(result);

            //
            if (ModelState.IsValid)//if input data to form ok 
            {
                if (peopleService.Delete(delete))
                {
                    ViewBag.Inform = "Successfully Person delted this person";
                }
                return RedirectToAction("Index");//return to DataBase page
            }
            return View(null);
        }//End DeleteOne action
        /*
        [HttpPost]//Action for <Form> to send information

        public IActionResult DeleteOne(Person create)
        {
            if (ModelState.IsValid)//if input data to form ok 
            {
               // peopleService.PersonAdd(create);
                return RedirectToAction("Index");//return to DataBase page
            }



            return View(create);

        }*/

        [HttpPost, ActionName("DeleteOne")]//Just use this
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost( 
                                           [Bind("Id,LastName,FirstName,PhoneNumber,CityName")] Person person)//index file
        {                  

           
            if (ModelState.IsValid)//if input data to form ok 
            {
                if (personService.Delete(person))
                {
                    ViewBag.Inform = "Successfully Person delted this person";
                }
                return RedirectToAction("Index");//return to DataBase page
            }
            return View(person);
        }//End DeleteOne action

        //Ajax

        public IActionResult Ajax()//For Ajax page
        {
            return View();
        }

        //
        public IActionResult GetPeople()
        {
            return PartialView("_ViewPeople", personService.Read());//updated part#5
        }


        [HttpPost]
        public IActionResult Details(int find)
        {
            //int result = Int32.Parse(find);


            return PartialView("_ViewPerson", personService.Read(find));
        }

        //Delete person

        [HttpPost]

        public IActionResult DeletePerson(int Id, [Bind("Id,LastName,FirstName,PhoneNumber,CityName")] 
                                                                 Person person)//index file
        {

            //int result = Int32.Parse(Id);
            Person delete = peopleService.FindById(Id);
            //ViewBag.Inform = "hellow I am here ";
            //
            if (ModelState.IsValid)//if input data to form ok 
            {
                if (personService.Delete(person))
                {
                    ViewBag.Inform = "The person with Id= " + Id + " is successfully  delted ";//_ViewPeople

                    // return RedirectToAction("DataBase");
                    //return View();//return _ViewPeople instead!

                    return PartialView("_ViewMsg");
                }
                //return RedirectToAction("DataBase");//return to DataBase page

                else
                {
                    ViewBag.Inform = "The Person is not  delted ";
                    return PartialView("_ViewPeople");
                    // return RedirectToAction("Main");
                }
            }


            //return PartialView("_ViewPerson");
            return PartialView("_ViewPeople");
        }//End Delete action

        public IActionResult Message()//
        {
            return View();
        }

    }//End class
}
