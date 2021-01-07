using DAL.Data;

namespace DAL.Repos.Factory
{
    public class MastersFactory
    {
        private readonly AppDbContext db;

        public MastersFactory(AppDbContext db) { this.db = db; }

        public ItemRepo GetItemRepo { get { return new ItemRepo(db); } }

        public GroupRepo GetGroupRepo { get { return new GroupRepo(db); } }
        



    }
}
