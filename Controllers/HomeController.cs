using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PenaltyCal_7.Models;

namespace PenaltyCal_7.Controllers;

public class HomeController : Controller
{
    PenaltyCalContext db = new PenaltyCalContext();

    // GET: Account/Login
    [HttpGet]
public ActionResult Index()

    {

        return View();

    }




    // POST: Account/Login
  [HttpPost]
 public ActionResult Index(LoginUser model)

    {

        // Check if the provided username and password match the stored data

        if (model.UserId == "UserId" && model.Password == "Password")

        {

            // Login successful, redirect to the desired page

            return RedirectToAction("SignUp", "Login");

        }

        else

        {

            // Login failed, display an error message

            ModelState.AddModelError("", "Invalid username or password.");

            return View(model);

        }

    }





    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

    public IActionResult Error()

    {

        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

    }

    
    public IActionResult Privacy()
    {
        return View();
    }

   
  
}
