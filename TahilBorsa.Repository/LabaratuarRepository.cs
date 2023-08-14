using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahilBorsaMS.Models.Entity;
using TahilBorsaMS.Models.Views;

namespace TahilBorsasi.Repository
{
    public class LabaratuarRepository : RepositoryBase<tblLabData>
    {
        public LabaratuarRepository(RepositoryContext context) : base(context) { }

        public List<V_LabList> GetLabList()
        {
            return RepositoryContext.LabListS.ToList<V_LabList>();
        }

        public List<V_EntryProductList> GetReadyLabList()
        {
           return RepositoryContext.EntryProductList.Where(x=> x.Process==false).ToList<V_EntryProductList>();
            
        }
    }
 
}
