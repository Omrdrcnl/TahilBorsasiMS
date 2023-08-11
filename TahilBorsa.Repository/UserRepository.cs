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
        public class UserRepository : RepositoryBase<tblUser>
        {
            public UserRepository(RepositoryContext context) : base(context) { }

        public void Sil(int id)
        {
            RepositoryContext.Users.Where(k => k.Id == id).ExecuteDelete();
        }
    }

}
