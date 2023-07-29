using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsasi.Repository
{
    public class TradesmanRepository : RepositoryBase<tblTradesman>
    {
        public TradesmanRepository(RepositoryContext context) : base(context) { }
    }
}
