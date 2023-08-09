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

        public List<tblDistrict> DistrictsByCity(int id)
        {
            List<tblDistrict> items = (from k in RepositoryContext.Districts
                                       join c in RepositoryContext.Cities on k.tblCityId equals c.Id 
                                       where k.tblCityId==id select k).ToList<tblDistrict>();
            return items;
        }

        public tblDistrict GetById(object districtId)
        {
            var item = RepositoryContext.Districts.Where(x => x.Id == (int)districtId).FirstOrDefault();
            return item;
            throw new NotImplementedException();
        }
    }
    
}
