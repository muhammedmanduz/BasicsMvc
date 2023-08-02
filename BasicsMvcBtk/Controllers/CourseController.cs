using BasicsMvcBtk.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicsMvcBtk.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            var model = Repository.Applications;

            return View(model);
        }
        public IActionResult Apply()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]//form üzerinnden gelen tehditler virusler için guvenlik sağlar 
        public IActionResult Apply([FromForm]Candidate model) //form uzerinden model binding(bilgiler geliyor)
        {
            if (Repository.Applications.Any(c=>c.Email.Equals(model.Email)))
            {
                ModelState.AddModelError("", "There is already an application for you !");
            }
            if (ModelState.IsValid)
            {
                Repository.Add(model);
                return View("Feedback", model);
            }
            return View();

           
        }
    }
}
