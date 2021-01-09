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

    public class CountryVM
    {
        public int Id { get; set; }
        public string CountryName { get; set; }        
        public string CountryCode { get; set; }        
        public bool IsActive { get; set; }
    }

    public class StateVM
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string StateName { get; set; }        
        public bool IsActive { get; set; }
    }
    public class CityVM
    {
        public int Id { get; set; }
        public int StateId { get; set; }
        public string CityName { get; set; }
        public bool IsActive { get; set; }
    }

    public class UnitVM
    {
        public int Id { get; set; }        
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }

    public class RegionVM
    {
        public int Id { get; set; }
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public bool IsActive { get; set; }
    }

    public class ProjectVM
    {
        public int Id { get; set; }
        public int RegionId { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public bool IsActive { get; set; }
    }

    public class CompanyVM
    {
        public int Id { get; set; }        
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public bool IsActive { get; set; }
    }

}
