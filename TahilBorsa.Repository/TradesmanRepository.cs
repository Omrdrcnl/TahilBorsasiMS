using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsasi.Repository
{
    public class TradesmanRepository : RepositoryBase<tblTradesman>
    {
        public TradesmanRepository(RepositoryContext context) : base(context) { }

        public void Delete(int tradesmanId)
        {
            RepositoryContext.Tradesmans.Where(x => x.Id == tradesmanId).ExecuteDelete();
        }

        public List<string> GetNumbers()
        {
            List<string> items = RepositoryContext.Tradesmans.Where(x=>x.Contact != null).Select(x => x.Contact).ToList();

            return items;
          
        }
    }
}
