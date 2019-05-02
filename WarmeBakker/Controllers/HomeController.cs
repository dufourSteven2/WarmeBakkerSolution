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
using Microsoft.AspNetCore.Mvc.Rendering;

//using WarmeBakker.Models.ProductViewModels.CategoryGroup;
//using WarmeBakker.Models.ProductViewModels;

namespace WarmeBakker.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMailService _mailService;
        private readonly IBakkerRepository _repository;
        private readonly WarmeBakkerContext _ctx;



        public HomeController (WarmeBakkerContext ctx, IBakkerRepository repository, IMailService mailService)
        {
            _mailService = mailService;
            _repository = repository;
            _ctx = ctx;
        }


        public  IActionResult Index()
        {

            var newsmessages = _repository.GetNewsMessages();
            return View(newsmessages);
        }

        public IActionResult Shop()
        {
            var result = _repository.GetAllProducts();
            return View(result.ToList());
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
            ViewData["Onderwerp"] = new SelectList(_ctx.topicsContactforms, "Id", "Title");
            PopulateTopicDropDownlist();
            return View();
        }

        private void PopulateTopicDropDownlist()
        {
            var departmentsQuery = from d in _ctx.topicsContactforms
                                    orderby d.Id
                                   select d;

            ViewBag.CategoryId = new SelectList(departmentsQuery, "Id", "Title");
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
