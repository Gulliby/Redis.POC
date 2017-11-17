using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Data.Entities;

namespace Data.Mapping
{
    public class CountriesMapping : EntityTypeConfiguration<CountryDb>
    {
        public CountriesMapping()
        {
            ToTable("COUNTRIES");
            Property(c => c.CountryId).HasColumnName("COUNTRYID");
            HasKey(c => c.CountryId);
            Property(c => c.CountryId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
