using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using CTC.Entities;
using Test.Authorization.Roles;
using Test.Authorization.Users;
using Test.MultiTenancy;

namespace Test.EntityFramework
{
    public class TestDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...
        public virtual DbSet<Person> Persons { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public TestDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in TestDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of TestDbContext since ABP automatically handles it.
         */
        public TestDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public TestDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public TestDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
