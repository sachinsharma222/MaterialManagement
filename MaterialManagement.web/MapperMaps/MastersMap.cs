using AutoMapper;
using Models.Entities;
using Models.ViewModels;

namespace MaterialManagement.web.MapperMaps
{
    public class ItemProfile:Profile
    {
        public ItemProfile()
        {
            this.CreateMap<Item, ItemVM>();
        }
    }

    public class ItemReverseProfile : Profile
    {
        public ItemReverseProfile()
        {
            this.CreateMap<ItemVM,Item>();
        }
    }

    public class ItemGroupProfile : Profile
    {
        public ItemGroupProfile()
        {
            this.CreateMap<ItemGroup, ItemGroupVM>();
        }
    }

    public class ItemGroupReverseProfile : Profile
    {
        public ItemGroupReverseProfile()
        {
            this.CreateMap<ItemGroupVM, ItemGroup>();
        }
    }

    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            this.CreateMap<Country, CountryVM>();
        }
    }
    public class CountryReverseProfile : Profile
    {
        public CountryReverseProfile()
        {
            this.CreateMap<CountryVM, Country>();
        }
    }

    public class StateProfile : Profile
    {
        public StateProfile()
        {
            this.CreateMap<State, StateVM>();
        }
    }
    public class StateReverseProfile : Profile
    {
        public StateReverseProfile()
        {
            this.CreateMap<StateVM, State>();
        }
    }

    public class CityProfile : Profile
    {
        public CityProfile()
        {
            this.CreateMap<City, CityVM>();
        }
    }
    public class CityReverseProfile : Profile
    {
        public CityReverseProfile()
        {
            this.CreateMap<CityVM, City>();
        }
    }

    public class UnitProfile : Profile
    {
        public UnitProfile()
        {
            this.CreateMap<Unit, UnitVM>();
        }
    }
    public class UnitReverseProfile : Profile
    {
        public UnitReverseProfile()
        {
            this.CreateMap<UnitVM, Unit>();
        }
    }

    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            this.CreateMap<Region, RegionVM>();
        }
    }
    public class RegionReverseProfile : Profile
    {
        public RegionReverseProfile()
        {
            this.CreateMap<RegionVM, Region>();
        }
    }

    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            this.CreateMap<Project, ProjectVM>();
        }
    }
    public class ProjectReverseProfile : Profile
    {
        public ProjectReverseProfile()
        {
            this.CreateMap<ProjectVM, Project>();
        }
    }

    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            this.CreateMap<Company, CompanyVM>();
        }
    }
    public class CompanyReverseProfile : Profile
    {
        public CompanyReverseProfile()
        {
            this.CreateMap<CompanyVM, Company>();
        }
    }

}
