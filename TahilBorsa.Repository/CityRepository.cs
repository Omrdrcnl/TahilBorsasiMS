using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsasi.Repository
{
    public class CityRepository : RepositoryBase<tblCity>
    {
        public CityRepository(RepositoryContext context) : base(context) { }
    }
   
}
