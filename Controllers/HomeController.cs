using Microsoft.AspNetCore.Mvc;
using dell_credhub_demo.Models;
using System;
using Newtonsoft.Json;

namespace dell_credhub_demo.Controllers
{
    public class HomeController : Controller
    {
        //     HomeController(SecretCredential credential) {

        //     }

        public IActionResult Index()
        {
            var vcapServicesJson = Environment.GetEnvironmentVariable("VCAP_SERVICES");
            dynamic vcapServicesObject = JsonConvert.DeserializeObject(vcapServicesJson);
            ViewData["credhubRef"] = vcapServicesObject.VCAP_SERVICES.credhub[0].credentials["credhub-ref"];
            return View();
        }
    }
}
