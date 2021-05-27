using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Dynamic;
using BookStoreUsingDotnetCoreMvc.Models;

namespace BookStoreUsingDotnetCoreMvc.Controllers
{
    public class HomeController: Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult AboutUs()
        {
            return View();
        }

        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
