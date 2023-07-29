using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsasi.Repository
{
    public class LabDataRepository : RepositoryBase<tblLabData>
    {
        public LabDataRepository(RepositoryContext context) : base(context) { }
    }
 
}
