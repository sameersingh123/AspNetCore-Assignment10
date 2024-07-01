using Assignment10.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment10.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return Content("Welcome to the Best Bank");
        }

        [Route("/account-details")]
        public IActionResult AccountDetails()
        {
            Person person = new Person() { acccountNumber = 1001, accountHolderName = "Example Name", currentBalance = 5000 };
            return Json(person);
        }

        [Route("/account-statement")]
        public IActionResult AccountStatement()
        {
            return File("carimg.jpg", "image/jpeg");
        }

        [Route("/get-current-balance/{accountNumber:int}")]
        public IActionResult GetCurrentBalance()
        {
            if (Request.RouteValues.ContainsKey("accountNumber"))
            {
                int accountNumber = Convert.ToInt32(Request.RouteValues["accountNumber"]);


                if (accountNumber == 1001)
                {
                    return Content("5000");
                }
                else
                {
                    return BadRequest("Account Number should be 1001");
                }
            }

            else
            {
                return BadRequest("Account Number should be supplied");
            }

        }

    }
}
