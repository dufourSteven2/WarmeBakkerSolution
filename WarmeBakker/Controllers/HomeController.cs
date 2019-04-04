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
using WarmeBakker.Services;

//using WarmeBakker.Models.ProductViewModels.CategoryGroup;
//using WarmeBakker.Models.ProductViewModels;

namespace WarmeBakker.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMailService _mailService;
        private readonly WarmeBakkerContext _context;



        public HomeController (WarmeBakkerContext context, IMailService mailService)
        {
            _mailService = mailService;
            _context = context;
        }


        public async Task <IActionResult> Index()
        {
            DateTime Today = DateTime.Today;
                var newsmessages = await _context.NewsMessages.Where(nm => nm.StartDate >= Today && Today <= nm.EndDate ).ToListAsync();
            return View(newsmessages);
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
        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost("Contact")]
        public IActionResult Contact(ContactViewModels model)
        {
            if (ModelState.IsValid)
            {
                //send email
                _mailService.SendMessage("benny.vanderschaeghe@proximus.be", model.Onderwerp, $"from: {model.Name} - {model.Email} - Message: {model.Message}" );
                ViewBag.UserMessage = "Bericht verstuurd.";
                ModelState.Clear();

            }
            else
            {

                //toon de fouten
            }
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
