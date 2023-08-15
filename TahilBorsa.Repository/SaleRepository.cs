using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahilBorsaMS.Models.Entity;
using TahilBorsaMS.Models.Views;

namespace TahilBorsasi.Repository
{
    public class SaleRepository : RepositoryBase<tblSale>
    {
        public SaleRepository(RepositoryContext context) : base(context) { }

        public List<V_ReadySale> GetReadySales()
        {
            return RepositoryContext.ReadySales.ToList<V_ReadySale>();
        }

        public List<V_SaledList> GetSaledList()
        {
            return RepositoryContext.SaledLists.ToList<V_SaledList>();
        }

     



    }

}
