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
                .BeforeMap((src, dest) => dest.HeadCategoryname =src.Category.Name)
                .AfterMap((src, dest) => dest.HeadCategoryname = src.Category.HeadCategory.Name );



                ;


                CreateMap<Category, CategoryDTO>().ReverseMap();
            });
        }
    }
}
