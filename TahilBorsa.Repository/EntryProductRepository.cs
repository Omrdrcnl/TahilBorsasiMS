using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahilBorsaMS.Models.Entity;
using TahilBorsaMS.Models.Views;

namespace TahilBorsasi.Repository
{
    public class EntryProductRepository : RepositoryBase<tblEntryProduct>
    {
        public EntryProductRepository(RepositoryContext context) : base(context) { }

        public List<V_EntryProductList> GetEntryProductList()
        {
            return RepositoryContext.EntryProductList.ToList<V_EntryProductList>();
        }

      
    }

}
