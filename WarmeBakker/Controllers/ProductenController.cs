using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using WarmeBakker.Data;
using WarmeBakker.Models;
using WarmeBakkerLib;

namespace WarmeBakker.Controllers
{
    public class ProductenController : Controller
    {
        private readonly WarmeBakkerContext _context;
        private readonly IBakkerRepository _repository;
        private readonly ILogger<ProductenController> _logger;
        private readonly IMapper _mapper;

        public ProductenController(WarmeBakkerContext context, IBakkerRepository repository, ILogger<ProductenController> logger, IMapper mapper)
        {
            _context = context;
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        // GET: Producten
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page, int headId)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
           

            var products = from s in _context.Products.Include(p => p.Category).
                           OrderBy(d => d.Category.HeadCategoryId).
                           OrderBy(d => d.Category.id)
                     select s;
                           

            switch (sortOrder)
            {
                case "Order by Headcategory":
                    products = products.OrderBy(p => p.Category.HeadCategoryId);
                    break;
                case "Order by id":
                    products = products.OrderBy(p => p.Category.Id);
                    break;
            }

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;




            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Category.Name.Contains(searchString));
                //(s => s.Category.Name.Contains(searchString) ||s =>s.Price.Contains(searchstring)) //kan ook is dan extra filter
            }



            PopulateHeadCategoryDropDownList();
            PopulateCategoryDropDownList();
            int pageSize = 15;
            return View(await PaginatedList<Product>.CreateAsync(products.AsNoTracking().Include(p => p.Category.HeadCategory), page ?? 1, pageSize));

            //return View(await products.AsNoTracking().ToListAsync());

            //var warmeBakkerContext = _context.Products.Include(p => p.Category);
            //return View(await warmeBakkerContext.ToListAsync());
        }

        // GET: Producten/Details/5
        public IActionResult Details(int id)
        {

            try
            {
                var product = _repository.GetProductById(id);
                if  (product != null)
                {   GetHeadCategories();
                    return View(_mapper.Map<Product, ProductDetailDTO>(product));
                    
                }


                else return NotFound();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get product: {ex}");
                return BadRequest("Bad request");

            }

        }
        // GET: Test/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id");
            PopulateCategoryDropDownList();
            return View();
        }

        // POST: Test/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Description,Highlight,Picture,CategoryId")] Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Products.Add(product);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateCategoryDropDownList(product.CategoryId);
            return View(product);

        }

        // GET: Test/Edit/5
        public  IActionResult Edit(int id)
        {

            try
            {
                var product = _repository.GetProductById(id);
                if (product != null)
                {
                   
                    ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", product.Category.Id);
                    PopulateCategoryDropDownList(product.Category.Id);
                    return View(_mapper.Map<Product, ProductDetailDTO>(product));
                }
                else return NotFound();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get product: {ex}");
                return BadRequest("Bad request");

            }




           // return View(product);
        }

        // POST: Test/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Description,Highlight,Picture,CategoryId")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", product.CategoryId);
                var product1 = _repository.GetProductById(id);
                PopulateCategoryDropDownList(product1.Category.Id);
                ViewBag.UserMessage = "Product gewijzigd";
                return View();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", product.CategoryId);
            ViewBag.UserMessage = "Product gewijzigd";
            return View();
        }



        // GET: Producten/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Producten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        private ActionResult GetHeadCategories()
        {
            var headcat = from d in _context.Categories
                          where (d.HeadCategory == null)
                          orderby d.Id
                          select d;

            return new JsonResult(headcat);
        }

        private JsonResult GetdCategories(int CategorieId)
        {
            var cat = new SelectList(_context.Categories.Where(c => c.HeadCategoryId == CategorieId), "Id", "Name");

            return  Json(cat);
        }


        private void PopulateCategoryDropDownList(object selectedCategory = null)
        {
            var departmentsQuery = from d in _context.Categories
                                   where(d.HeadCategory != null)
                                   orderby d.Id
                                   select d;
            
            ViewBag.CategoryId = new SelectList(departmentsQuery, "Id", "Name", selectedCategory);
        }

        private void PopulateHeadCategoryDropDownList()
        {
            var headcat = from d in _context.Categories
                      where (d.HeadCategory == null)
                      orderby d.Id
                      select d;

            ViewBag.HeadCat = new SelectList(headcat, "Id", "Name");
        }


        private void PopulateCategoryDropDownList()
        {
            var departmentsQuery = from d in _context.Categories
                                   where (d.HeadCategory != null)
                                   orderby d.Id
                                   select d;

            ViewBag.CategoryId = new SelectList(departmentsQuery, "Id", "Name");
        }



    }
}
