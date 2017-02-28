using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_core.net.Controllers
{
    [Route("/")]
    public class TestController
    {
        [HttpGet]
        public IActionResult Get()
        {
            return new ObjectResult("Je l'ai pas touché !");
        }
    }
}
