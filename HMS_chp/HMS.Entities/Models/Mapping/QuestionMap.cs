using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class QuestionMap : EntityTypeConfiguration<Question>
    {
        public QuestionMap()
        {
            // Primary Key
            this.HasKey(t => t.QuestionId);

            // Properties
            this.Property(t => t.QuestionId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Questions");
            this.Property(t => t.QuestionId).HasColumnName("QuestionId");
            this.Property(t => t.QuestionSLNo).HasColumnName("QuestionSLNo");
            this.Property(t => t.QuestionText).HasColumnName("QuestionText");
            this.Property(t => t.QuizId).HasColumnName("QuizId");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
        }
    }
}
