using Microsoft.AspNetCore.Mvc;
using PenaltyCal_7.Models;

namespace PenaltyCal_7.Controllers
{
    //[Route("[controller]")]


    public class RegistrationController : Controller
    {

        /*   MyDbContext db = new MyDbContext();
           [HttpGet]
            public IActionResult Register()
           {
               return View();
           }

           [HttpPost]
           public IActionResult Register(RegisterViewModel model)
           {
               if(ModelState.IsValid)
               {

                   //using (var DbContext = new MyDbContext())
           {
               db.RegisterViewModels?.Add(model);
                                           db.SaveChanges();
           }



                   return RedirectToAction ("Success");
               }
               return View(model);
           }
           public IActionResult Success()
           {
               return View();
           }


           public IActionResult Index()
           {
               return View();
           }

           [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
           public IActionResult Error()
           {
               return View("Error!");
           }
           */

        private readonly PenaltyCalContext _dbContext;

        public RegistrationController(PenaltyCalContext dbContext)
        {
            _dbContext = dbContext;
        }
[HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(SignupUser model)
        {
            if (ModelState.IsValid)
            {
                    _dbContext.SignupUsers?.Add(model);
                    _dbContext.SaveChanges();
                
                     return RedirectToAction("Login");
            }
                     return View(model);
        }
        


    }

}
