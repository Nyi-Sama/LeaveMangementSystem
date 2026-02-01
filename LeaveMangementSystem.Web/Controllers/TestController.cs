using LeaveMangementSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeaveMangementSystem.Web.Controllers
{
    public class TestController : Controller
    {
        public IActionResult TestPage()
        {
            var data = new TestViewModel()
            {
                Name = "Test",
                Age = 1,
            };

            return View(data);
        }
    }
}
