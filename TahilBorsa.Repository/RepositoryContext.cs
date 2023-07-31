
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TahilBorsaMS.Models.Entity;


namespace TahilBorsasi.Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }


        public DbSet<tblProduct> Products { get; set; }
        public DbSet<tblFarmer> Farmers { get; set; }
        public DbSet<tblAddress> Addresses { get; set; }
        public DbSet<tblCity> Cities { get; set; }
        public DbSet<tblDistrict> Districts { get; set; }
        public DbSet<tblEntryProduct> EntryProducts { get; set; }
        public DbSet<tblLabData> LabDatas { get; set; }
        public DbSet<tblTradesman> Tradesmans { get; set; }
        public DbSet<tblSale> Sales { get; set; }

    }
}
