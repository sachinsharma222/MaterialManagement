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

    public class VendorVM
    {
        public int Id { get; set; }
        public string CompanyId { get; set; }
        public string ProjectId { get; set; }        
        public string VendorID { get; set; }       
        public string Name { get; set; }
        public string Address { get; set; }        
        public string Country { get; set; }       
        public string State { get; set; }        
        public string City { get; set; }       
        public string MobileNo { get; set; }        
        public string Email { get; set; }        
        public string VendorType { get; set; }
        public bool IsActive { get; set; }        
        public string PanNo { get; set; }       
        public string TinNo { get; set; }       
        public string EccNo { get; set; }        
        public string RegistrationType { get; set; }        
        public string PinCode { get; set; }        
        public string SalesTaxNo { get; set; }        
        public string CSTNo { get; set; }        
        public string ServiceTaxNo { get; set; }        
        public string PhoneNo { get; set; }        
        public string BlackListStatus { get; set; }        
        public string ContactPerson { get; set; }        
        public string MulRegistrationType { get; set; }        
        public string VAT_No { get; set; }        
        public string GST_NO { get; set; }        
        public string Aadhaar_No { get; set; }
    }

    public class VendorRegistrationTypeVM
    {
        public int Id { get; set; }
        public string CompanyID { get; set; }
        public string TypeID { get; set; }
        public string VendorType { get; set; }
        public bool IsActive { get; set; }

    }

    public class RefTableVM
    {
        public int Id { get; set; }
        public string Ref_Code { get; set; }        
        public string Ref_GroupName { get; set; }
        public string Ref_Name { get; set; }
        public bool IsActive { get; set; }
    }

}
