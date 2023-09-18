using Homework_03_27_PeopleListPost.Web.Models;
using Microsoft.AspNetCore.Mvc;
using PeopleListPost.Data;
using System.Diagnostics;

namespace Homework_03_27_PeopleListPost.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            PeopleDataBase peopleDB = new();
            PeopleViewModel peopleVM = new()
            {
                People = peopleDB.GetPeople()
            };
            return View(peopleVM);
        }



        public IActionResult AddForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(List<Person> people)
        {
            PeopleDataBase peopleDB = new();
            peopleDB.AddManyPeople(people);
            return Redirect("/");
        }

    }
}