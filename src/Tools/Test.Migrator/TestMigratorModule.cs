using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Test.EntityFramework;

namespace Test.Migrator
{
    [DependsOn(typeof(TestDataModule))]
    public class TestMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<TestDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}