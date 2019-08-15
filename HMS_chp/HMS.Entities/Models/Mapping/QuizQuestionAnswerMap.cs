using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class QuizQuestionAnswerMap : EntityTypeConfiguration<QuizQuestionAnswer>
    {
        public QuizQuestionAnswerMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            //this.Property(t => t.Id)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("QuizQuestionAnswers");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.QuestionId).HasColumnName("QuestionId");
            this.Property(t => t.AnswerChoiceId).HasColumnName("AnswerChoiceId");
            this.Property(t => t.IsActive).HasColumnName("IsActive");

            // Relationships
            this.HasRequired(t => t.AnswerChoice)
                .WithMany(t => t.QuizQuestionAnswers)
                .HasForeignKey(d => d.AnswerChoiceId);
            this.HasRequired(t => t.Question)
                .WithMany(t => t.QuizQuestionAnswers)
                .HasForeignKey(d => d.QuestionId);

        }
    }
}
