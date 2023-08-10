using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsasi.Repository
{
    public class FarmerRepository : RepositoryBase<tblFarmer>
    {
        public FarmerRepository(RepositoryContext context) : base(context) { }
        public void Delete(int farmerId)
        {
            RepositoryContext.Farmers.Where(x => x.Id == farmerId).ExecuteDelete();
        }
        public dynamic GetFarmerById(int farmerId)
        {
            List<tblFarmer> items = (from k in RepositoryContext.Farmers join u in RepositoryContext.Addresses
                                     on k.tblAddressId equals u.Id
                                     where k.Id == farmerId
                                     select k).ToList<tblFarmer>();
            return items;

        }
    }

}
