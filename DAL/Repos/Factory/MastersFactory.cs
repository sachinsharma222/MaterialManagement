using DAL.Data;
using Models.Entities;

namespace DAL.Repos.Factory
{
    public class MastersFactory
    {
        private readonly AppDbContext db;

        public MastersFactory(AppDbContext db) { this.db = db; }
        public ItemRepo GetItemRepo { get { return new ItemRepo(db); } }
        public GroupRepo GetGroupRepo { get { return new GroupRepo(db); } }
        public CountryRepo GetCountryRepo { get { return new CountryRepo(db); } }
        public StateRepo GetStateRepo { get { return new StateRepo(db); } }
        public CityRepo GetCityRepo { get { return new CityRepo(db); } }
        public UnitRepo GetUnitRepo { get { return new UnitRepo(db); } }
        public RegionRepo GetRegionRepo { get { return new RegionRepo(db); } }
        public ProjectRepo GetProjectRepo { get { return new ProjectRepo(db); } }
        public CompanyRepo GetCompanyRepo { get { return new CompanyRepo(db); } }
        public VendorRepo GetVendorRepo { get { return new VendorRepo(db); } }
        public VendorRegistrationTypeRepo GetVendorRegistrationTypeRepo { get { return new VendorRegistrationTypeRepo(db); } }
        public RefTableRepo GetRefTableRepo { get { return new RefTableRepo(db); } }



    }
}
