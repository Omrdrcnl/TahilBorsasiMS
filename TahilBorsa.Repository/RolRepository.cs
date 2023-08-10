using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahilBorsaMS.Models.Entity;
using TahilBorsasi.Repository;

namespace TahilBorsa.Repository
{
    public class RolRepository : RepositoryBase<tblRol>
    {
        public RolRepository(RepositoryContext context) : base(context) { }
        public void RolSil(int rolId)
        {
            RepositoryContext.Rols.Where(r => r.Id == rolId).ExecuteDelete();
        }
    }
}
