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


    public class VendorProfile : Profile
    {
        public VendorProfile()
        {
            this.CreateMap<Vendor, VendorVM>();
        }
    }
    public class VendorReverseProfile : Profile
    {
        public VendorReverseProfile()
        {
            this.CreateMap<VendorVM, Vendor>();
        }
    }

    public class VendorRegistrationTypeProfile : Profile
    {
        public VendorRegistrationTypeProfile()
        {
            this.CreateMap<VendorRegistrationType, VendorRegistrationTypeVM>();
        }
    }
    public class VendorRegistrationTypeReverseProfile : Profile
    {
        public VendorRegistrationTypeReverseProfile()
        {
            this.CreateMap<VendorRegistrationTypeVM, VendorRegistrationType>();
        }
    }

    public class RefTableProfile : Profile
    {
        public RefTableProfile()
        {
            this.CreateMap<RefTable, RefTableVM>();
        }
    }
    public class RefTableReverseProfile : Profile
    {
        public RefTableReverseProfile()
        {
            this.CreateMap<RefTableVM, RefTable>();
        }
    }

}
