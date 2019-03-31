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
                CreateMap<Product, ProductDetailDTO>().ReverseMap()
                    .ForMember(dto => dto.SubCategory, conf => conf.MapFrom(gem => gem.CategoryName));
                CreateMap<SubCategory, SubCategoryDTO>().ReverseMap();
                CreateMap<Category, CategoryDTO>().ReverseMap();
            });
        }
    }
}
