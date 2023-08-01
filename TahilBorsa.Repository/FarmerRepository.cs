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
    }

}
