using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MicroService.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase{
        private static readonly string[] Summaries = new[]{
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<MainController> _logger;

        public MainController(ILogger<MainController> logger){
            _logger = logger;
        }

        
    }
}