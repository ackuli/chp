using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class QuestionDetailMap : EntityTypeConfiguration<QuestionDetail>
    {
        public QuestionDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            //this.Property(t => t.Id)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.QuestionDetailsText)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("QuestionDetails");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.QuestionId).HasColumnName("QuestionId");
            this.Property(t => t.QuestionDetailsText).HasColumnName("QuestionDetailsText");
            this.Property(t => t.IsActive).HasColumnName("IsActive");

            // Relationships
            this.HasRequired(t => t.Question)
                .WithMany(t => t.QuestionDetails)
                .HasForeignKey(d => d.QuestionId);

        }
    }
}
