using Microsoft.AspNetCore.Mvc;
using dell_credhub_demo.Models;

namespace dell_credhub_demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly SecretCredential credential;

        public HomeController(SecretCredential credential) {
            this.credential = credential;
        }

        public IActionResult Index()
        {
            ViewData["connString"] = credential.ConnectionString;
            return View();
        }
    }
}
