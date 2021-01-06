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
            return db.Items.Include(x => x.Group).Include(x => x.Group).FirstOrDefault(x => x.Id == id);
        }

    }

    public class GroupRepo : BaseRepo<ItemGroup>
    {
        public GroupRepo(AppDbContext db) : base(db)
        {

        }
    }
}
