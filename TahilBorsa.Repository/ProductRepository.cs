﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahilBorsaMS.Models.Entity;


namespace TahilBorsasi.Repository
{
    public class ProductRepository : RepositoryBase<tblProduct>
    {
        public ProductRepository(RepositoryContext context) : base(context) { }

        public void Delete(int productId)
        {
            RepositoryContext.Products.Where(x => x.Id == productId).ExecuteDelete();
        }

    }
}
