using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WarmeBakker.Models;
using Microsoft.EntityFrameworkCore;
using WarmeBakker.Data;
using WarmeBakker.ViewModels;
//using WarmeBakker.Models.ProductViewModels.CategoryGroup;
//using WarmeBakker.Models.ProductViewModels;

namespace WarmeBakker.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {

            //    IQueryable<CategoryGroup> data =
            //from product in _context.Products
            //group product by student.EnrollmentDate into dateGroup
            //select new CategoryGroup()
            //{
            //    product = categoryGroup.Key,
            //    ProductCount = categoryGroup.Count()
            //};
            //    return View(await data.AsNoTracking().ToListAsync());

            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact(ContactViewModels model)
        {
               return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
