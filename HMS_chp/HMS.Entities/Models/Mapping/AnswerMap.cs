using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class AnswerMap : EntityTypeConfiguration<Answer>
    {
        public AnswerMap()
        {
            // Primary Key
            this.HasKey(t => t.AnswerId);

            // Properties
            // Table & Column Mappings
            this.ToTable("Answers");
            this.Property(t => t.AnswerId).HasColumnName("AnswerId");
            this.Property(t => t.AnswerText).HasColumnName("AnswerText");
            this.Property(t => t.WhyAnswerCorrect).HasColumnName("WhyAnswerCorrect");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
        }
    }
}
