using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class AnswerChoiceMap : EntityTypeConfiguration<AnswerChoice>
    {
        public AnswerChoiceMap()
        {
            // Primary Key
            this.HasKey(t => t.AnswerChoiceId);

            // Properties
            this.Property(t => t.Choices)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("AnswerChoices");
            this.Property(t => t.AnswerChoiceId).HasColumnName("AnswerChoiceId");
            this.Property(t => t.Choices).HasColumnName("Choices");
            this.Property(t => t.QuestionId).HasColumnName("QuestionId");
            this.Property(t => t.IsAnswer).HasColumnName("IsAnswer");
            this.Property(t => t.WhyAnswerCorrect).HasColumnName("WhyAnswerCorrect");
            this.Property(t => t.IsActive).HasColumnName("IsActive");

            // Relationships
            this.HasRequired(t => t.Question)
                .WithMany(t => t.AnswerChoices)
                .HasForeignKey(d => d.QuestionId);

        }
    }
}
