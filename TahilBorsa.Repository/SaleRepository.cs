using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsasi.Repository
{
    public class SaleRepository : RepositoryBase<tblSale>
    {
        public SaleRepository(RepositoryContext context) : base(context) { }

        //public dynamic OfTheShelf()
        //{
        //    List<tblSale> list =(from k in RepositoryContext.Sales join u in RepositoryContext.EntryProducts
        //                         on k.tblEntryProductId equals u.Id
        //                         where u.Process==false 
        //                         select k).ToList<tblSale>();
        //    return list;
        //}



    }

}
