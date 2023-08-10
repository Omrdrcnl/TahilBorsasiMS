using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahilBorsaMS.Models.Entity;
using TahilBorsasi.Repository;

namespace TahilBorsa.Repository
{
    public class ContactRepository : RepositoryBase<tblContact>
    {
        public ContactRepository(RepositoryContext context): base(context)
        {
            
        }
    }
}
