using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WarmeBakker.Data;
using WarmeBakker.Models;
using WarmeBakkerLib;

namespace WarmeBakker.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private readonly IBakkerRepository _repository;
        private readonly ILogger<ProductController> _logger;
        private readonly IMapper _mapper;

        public ProductController(IBakkerRepository repository, ILogger<ProductController>logger, IMapper mapper )
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<Product>> Get()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(_repository.GetAllProducts()));
            }
            catch(Exception ex)
            {
                _logger.LogError($"Failed to get products: {ex}");
                return BadRequest("Bad request");

            }
            
        }

        [HttpGet("{id:int}")]
        public ActionResult Get(int id)
        {
            try
            {
                var product = _repository.GetProductById(id);
                if (product != null) return Ok(_mapper.Map<Product, ProductDetailDTO>(product));
                else return NotFound();
               
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get products: {ex}");
                return BadRequest("Bad request");

            }
        }


        //[HttpPost]
        //public ActionResult Post([FromBody]ProductDetailDTO productDetail  )
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var newProduct = _mapper.Map<ProductDetailDTO, Product>();

        //            _repository.AddEntity(newProduct);
        //            if (_repository.SaveAll())
        //            {
        //                var pm = new ProductDetailDTO()
        //                {
                          
        //                    Id = newProduct.Id,
        //                    Name = newProduct.Name,
        //                    Price = newProduct.Price,
        //                    Description = newProduct.Description,
        //                    Highlight = newProduct.Highlight,
        //                    Picture = newProduct.Picture,
        //                    CategoryName = newProduct.Category.Name,
        //                    HeadCategoryname = newProduct.Category.HeadCategory.Name

        //                };

        //            }
        //        }
        //    }
        }
    }

   
