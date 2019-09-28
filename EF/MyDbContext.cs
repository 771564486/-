using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace EF
{
    public class MyDbContext:DbContext
    {
        public MyDbContext():base("sql")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MyDbContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Compensation> Compensation { get; set; }
        public DbSet<Compensation_issue> Compensation_issue { get; set; }
        public DbSet<SJKB> SJKB { get; set; }
        public DbSet<SJKL> SJKL { get; set; }
    }
}
