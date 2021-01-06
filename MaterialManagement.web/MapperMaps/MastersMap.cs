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

    public class ItemGroupProfile : Profile
    {
        public ItemGroupProfile()
        {
            this.CreateMap<ItemGroup, ItemGroupVM>();
        }
    }
}
