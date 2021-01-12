using AutoMapper;
using Models.Entities;
using Models.ViewModels;

namespace MaterialManagement.web.MapperMaps
{
    public class ItemProfile:Profile
    {
        public ItemProfile()
        {
            this.CreateMap<Item, ItemVM>().ReverseMap();
        }
    }

    public class ItemGroupProfile : Profile
    {
        public ItemGroupProfile()
        {
            this.CreateMap<ItemGroup, ItemGroupVM>().ReverseMap();
        }
    }

    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            this.CreateMap<Country, CountryVM>().ReverseMap();
        }
    }
    public class StateProfile : Profile
    {
        public StateProfile()
        {
            this.CreateMap<State, StateVM>().ReverseMap();
        }
    }

    public class CityProfile : Profile
    {
        public CityProfile()
        {
            this.CreateMap<City, CityVM>().ReverseMap();
        }
    }
    public class UnitProfile : Profile
    {
        public UnitProfile()
        {
            this.CreateMap<Unit, UnitVM>().ReverseMap();
        }
    }
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            this.CreateMap<Region, RegionVM>().ReverseMap();
        }
    }
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            this.CreateMap<Project, ProjectVM>().ReverseMap();
        }
    }
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            this.CreateMap<Company, CompanyVM>().ReverseMap();
        }
    }

}
