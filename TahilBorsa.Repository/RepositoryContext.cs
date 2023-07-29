
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
    
    public DbSet<tblProductName> tblProductName {  get; set; }
    public DbSet<tblFarmer> tblFarmer { get; set; }
    public DbSet<tblAddress> tblAddress { get; set; }
    public DbSet<tblCity> tblCity { get; set; }
    public DbSet<District> District { get; set; }
    public DbSet<tblEntryProduct> tblEntryProduct { get; set; }
    public DbSet<tblLabData> tblLabData { get; set; }
    public DbSet<tblTradesman> tblTradesman { get; set; }
    public DbSet<tblSale> tblSale { get; set; }

    }
}
