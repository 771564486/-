using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
namespace EF.Config
{
    public class CompensationConfig : EntityTypeConfiguration<Compensation>
    {
       public CompensationConfig()
       {
           this.ToTable("Compensation");
           this.HasKey(e=>e.Comid);
           this.Property(e => e.Comname).HasMaxLength(20);
       }

    }
}
