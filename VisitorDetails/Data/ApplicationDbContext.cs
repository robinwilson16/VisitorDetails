using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorDetails.Models;

namespace VisitorDetails.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            IConfiguration _configuration)
            : base(options)
        {
            configuration = _configuration;
        }

        public IConfiguration configuration { get; }

        public DbSet<PurposeOfVisit> PurposeOfVisit { get; set; }
        public DbSet<Site> Site { get; set; }
        public DbSet<SystemSetting> SystemSetting { get; set; }
        public DbSet<Visitor> Visitor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Site>()
                .HasKey(k => new { k.SiteCode });

            ////Prevent creating table in EF Migration
            //modelBuilder.Entity<Site>(entity => {
            //    entity.ToView("Site", "dbo");
            //});

            modelBuilder.Entity<SystemSetting>()
                .HasNoKey();
        }

        //Rename migration history table
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                x => x.MigrationsHistoryTable("__VIS_EFMigrationsHistory", "dbo"));
    }
}
