namespace Models.ViewModels
{
    public class ItemVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
        public bool IsActive { get; set; }
        public int UnitId { get; set; }
        public string GroupName { get; set; }
        public string UnitName { get; set; }
    }

    public class ItemGroupVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
