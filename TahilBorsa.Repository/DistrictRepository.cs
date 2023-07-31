using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahilBorsaMS.Models.Entity;


namespace TahilBorsasi.Repository
{
    public class DistrictRepository : RepositoryBase<tblDistrict>
    {
        public DistrictRepository(RepositoryContext context) : base(context) { }

        public List<tblDistrict> DistrictsByCity(int ilPlaka)
        {
            List<tblDistrict> items = (from k in RepositoryContext.Districts
                                       join c in RepositoryContext.Cities on k.tblCityId equals c.Id 
                                       where k.tblCityId==ilPlaka select k).ToList<tblDistrict>();
            return items;
        }
    }
    
}
