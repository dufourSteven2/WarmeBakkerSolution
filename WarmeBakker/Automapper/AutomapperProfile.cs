using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarmeBakkerLib;
using WarmeBakker.Models;

namespace WarmeBakker.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            Mapper.Initialize(cfg =>
            {
                CreateMap<Product, ProductDTO>().ReverseMap();




                CreateMap<Product, ProductDetailDTO>()
                .BeforeMap((src, dest) => src.Category.HeadCategory.Name = src.Category.HeadCategory.Name)
                .AfterMap((src, dest) => dest.HeadCategoryname = dest.HeadCategoryname);



                ;


                CreateMap<Category, CategoryDTO>().ReverseMap();
            });
        }
    }
}
