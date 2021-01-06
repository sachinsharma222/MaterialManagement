using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    public class ItemGroup : EntityBase
    {
        [Required]
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }

    public class Unit : EntityBase
    {
        [Required]
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }

    public class Item : EntityBase
    {
        [Required]
        public string Name { get; set; }
        public int GroupId { get; set; }
        [ForeignKey("GroupId")]
        public ItemGroup Group { get; set; }
        public bool IsActive { get; set; }
        public int UnitId { get; set; }
        [ForeignKey("UnitId")]
        public Unit Unit { get; set; }

        //optional
        public string Make { get; set; }
        public string PartNo { get; set; }
        public string HSN { get; set; }
        public string SKU { get; set; }
    }
    public class Region : EntityBase
    {
        [Required]
        public string RegionCode { get; set; }
        [Required]
        public string RegionName { get; set; }
        public bool IsActive { get; set; }


    }

    public class Project : EntityBase
    {
        public int RegionId { get; set; }
        [ForeignKey("RegionId")]
        public Region Region { get; set; }
        [Required]
        public string ProjectCode { get; set; }
        [Required]
        public string ProjectName { get; set; }
        public bool IsActive { get; set; }

    }

    public class Company : EntityBase
    {
        [Required]
        public string CompanyCode { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public bool IsActive { get; set; }
    }

    public class Country : EntityBase
    {
        [Required]
        public string CountryName { get; set; }
        [Required]
        public string CountryCode { get; set; }
        public bool IsActive { get; set; }
    }
    public class State : EntityBase
    {
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country Country { get; set; }
        [Required]
        public string StateName { get; set; }
        public bool IsActive { get; set; }
    }
    public class City : EntityBase
    {
        public int StateId { get; set; }
        [ForeignKey("StateId")]
        public State State { get; set; }
        [Required]
        public string CityName { get; set; }
        public bool IsActive { get; set; }
    }
}
