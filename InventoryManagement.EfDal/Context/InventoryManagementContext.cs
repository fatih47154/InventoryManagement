using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using InventoryManagement.EfDal.Migrations;
using InventoryManagement.Entities.Mapping;
using InventoryManagement.Entities.Tables;

namespace InventoryManagement.EfDal.Context
{
    public class InventoryManagementContext : DbContext
    {
        public InventoryManagementContext() : base("InventoryManagementDatabase")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<InventoryManagementContext, InventoryManagement.EfDal.Migrations.Configuration>());
        }
        public DbSet<DeviceType> DeviceTypes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<OperationType> OperationTypes { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new DeviceTypeMap());
            modelBuilder.Configurations.Add(new LocationMap());
            modelBuilder.Configurations.Add(new ModelMap());
            modelBuilder.Configurations.Add(new CompanyMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new OperationMap());
            modelBuilder.Configurations.Add(new OperationTypeMap());
            modelBuilder.Configurations.Add(new StatusMap());
            modelBuilder.Configurations.Add(new StoreMap());
        }
    }
}
