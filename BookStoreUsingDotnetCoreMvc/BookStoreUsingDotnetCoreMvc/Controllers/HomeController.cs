using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreUsingDotnetCoreMvc.Controllers
{
    public class HomeController: Controller
    {
        public string Index()
        {
            return "Web method";
        }
    }
}
