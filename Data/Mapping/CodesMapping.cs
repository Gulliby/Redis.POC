using Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.Mapping
{
    public class CodesMapping : EntityTypeConfiguration<CodesDb>
    {
        public CodesMapping()
        {
            ToTable("CODES");
            Property(c => c.CodeId).HasColumnName("CODEID");
            HasKey(c => c.CodeId);
            Property(c => c.CodeId);
        }
    }
}
