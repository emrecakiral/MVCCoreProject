using AutoMapper;
using MVCCoreProject.Models.Entities;
using MVCCoreProject.Models.ViewModels;

namespace MVCCoreProject.Models.MappingProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Products, ProductsViewModel>();
            CreateMap<Region, RegionViewModel>();
        }
    }
}
