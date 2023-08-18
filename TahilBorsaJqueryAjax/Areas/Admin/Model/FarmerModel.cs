namespace TahilBorsaJqeryAjax.Areas.Admin.Model
{
    public class FarmerModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNo { get; set; }
        public string Contact { get; set; }
        public int AddressId { get; set; }
        public DateTime? BirthDate { get; set; }

        public string? NeighborhoodName { get; set; }
        public string? FullAddress { get; set; }

        public int tblCityId { get; set; }
        public int tblDistrictId { get; set; }

       
    }
}
