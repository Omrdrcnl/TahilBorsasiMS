namespace TahilBorsa.Api.Controllers
{
    public class CiftciEkleRequestModel
    {
        public int FarmerId { get; set; }
        public DateTime BirthDate { get; set; }
        public string Contact { get; set; }
        public string FirstName { get; set; }
        public string IdentityNo { get; set; }
        public string LastName{get; set;}
        public int AddressId { get; set; }
        public string FullAddress { get; set; }
        public string NeighborhoodName { get; set; }
        public int tblDistrictId { get; set; }
        public int tblCityId { get; set; }

    }
};