
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TahilBorsaMS.Models.Entity;
using TahilBorsaMS.Models.Views;

namespace TahilBorsasi.Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        //Viev olusturdugumuzda privatekey olmadıgında asagadaki methodu override edip keyi olmadığını belirtiyoryz
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<V_EntryProductList>().HasNoKey();
            modelBuilder.Entity<V_LabList>().HasNoKey();
            modelBuilder.Entity<V_ReadySale>().HasNoKey();
            modelBuilder.Entity<V_SaledList>().HasNoKey();
       
            //date null hatasını giderdik asagıda da
            modelBuilder.Entity<tblEntryProduct>().Property(d => d.DateTime).HasDefaultValue();
            modelBuilder.Entity<tblSale>().Property(d => d.Quantity).HasDefaultValue();
            modelBuilder.Entity<tblSale>().Property(d => d.ActualPrice).HasDefaultValue();



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
        public DbSet<tblUser> Users { get; set; }
        public DbSet<tblRol> Rols { get; set; }
        public DbSet<tblContact> Contacts { get; set; }
        public DbSet<V_EntryProductList> EntryProductList { get; set; }
        public DbSet<V_LabList> LabListS { get; set; }
        public DbSet<V_ReadySale> ReadySales{ get; set; }
        public DbSet<V_SaledList> SaledLists { get; set; }
        



    }
}
