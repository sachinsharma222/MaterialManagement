using DAL.Data;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    public class ItemRepo : BaseRepo<Item>
    {
        private readonly AppDbContext db;

        public ItemRepo(AppDbContext db) : base(db)
        {
            this.db = db;
        }

        public IEnumerable<Item> GetWithGroupAndUnit()
        {
           return db.Items.Include(x => x.Group).Include(x => x.Unit).ToList();
        }

        public Item GetWithGroupAndUnit(int id)
        {
            return db.Items.Include(x => x.Group).Include(x => x.Unit).FirstOrDefault(x => x.Id == id);
        }

    }

    public class GroupRepo : BaseRepo<ItemGroup>
    {
        private readonly AppDbContext db;
        public GroupRepo(AppDbContext db) : base(db)
        {
            this.db = db;
        }        
    }


    public class CountryRepo : BaseRepo <Country>
    {
        private readonly AppDbContext db;
        public CountryRepo(AppDbContext db) : base(db)
        {
            this.db = db;
        }
        
    }

    public class StateRepo : BaseRepo<State>
    {
        private readonly AppDbContext db;
        public StateRepo(AppDbContext db) : base(db)
        {
            this.db = db;
        }

    }

    public class CityRepo : BaseRepo<City>
    {
        private readonly AppDbContext db;
        public CityRepo(AppDbContext db) : base(db)
        {
            this.db = db;
        }

    }

    public class UnitRepo : BaseRepo<Unit>
    {
        private readonly AppDbContext db;
        public UnitRepo(AppDbContext db) : base(db)
        {
            this.db = db;
        }

    }

    public class RegionRepo : BaseRepo<Region>
    {
        private readonly AppDbContext db;
        public RegionRepo(AppDbContext db) : base(db)
        {
            this.db = db;
        }

    }

    public class ProjectRepo : BaseRepo<Project>
    {
        private readonly AppDbContext db;
        public ProjectRepo(AppDbContext db) : base(db)
        {
            this.db = db;
        }

    }

    public class CompanyRepo : BaseRepo<Company>
    {
        private readonly AppDbContext db;
        public CompanyRepo(AppDbContext db) : base(db)
        {
            this.db = db;
        }
    }


    public class VendorRepo : BaseRepo<Vendor>
    {
        private readonly AppDbContext db;
        public VendorRepo(AppDbContext db) : base(db)
        {
            this.db = db;
        }
    }
    public class VendorRegistrationTypeRepo : BaseRepo<VendorRegistrationType>
    {
        private readonly AppDbContext db;
        public VendorRegistrationTypeRepo(AppDbContext db) : base(db)
        {
            this.db = db;
        }
    }

    public class RefTableRepo : BaseRepo<RefTable>
    {
        private readonly AppDbContext db;
        public RefTableRepo(AppDbContext db) : base(db)
        {
            this.db = db;
        }
    }
}
