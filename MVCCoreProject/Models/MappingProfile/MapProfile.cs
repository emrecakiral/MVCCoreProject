using AutoMapper;
using MVCCoreProject.Areas.Manage.Models.ViewModels;
using MVCCoreProject.Models.Entities;

namespace MVCCoreProject.Models.MappingProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Products, ProductsViewModel>();
            CreateMap<Region, RegionViewModel>();
            CreateMap<Customer, CustomerViewModel>();
        }
    }
}
