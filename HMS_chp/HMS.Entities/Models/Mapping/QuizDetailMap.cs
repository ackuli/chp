using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class QuizDetailMap : EntityTypeConfiguration<QuizDetail>
    {
        public QuizDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("QuizDetails");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.QuizId).HasColumnName("QuizId");
            this.Property(t => t.QuestionId).HasColumnName("QuestionId");
            this.Property(t => t.Score).HasColumnName("Score");
            this.Property(t => t.GivenAnswerChoiceId).HasColumnName("GivenAnswerChoiceId");
            this.Property(t => t.CorrectAnswerChoiceId).HasColumnName("CorrectAnswerChoiceId");

            // Relationships
            this.HasOptional(t => t.AnswerChoice)
                .WithMany(t => t.QuizDetails)
                .HasForeignKey(d => d.GivenAnswerChoiceId);
            this.HasRequired(t => t.AnswerChoice1)
                .WithMany(t => t.QuizDetails1)
                .HasForeignKey(d => d.CorrectAnswerChoiceId);
            this.HasRequired(t => t.Question)
                .WithMany(t => t.QuizDetails)
                .HasForeignKey(d => d.QuestionId);
            this.HasRequired(t => t.Quiz)
                .WithMany(t => t.QuizDetails)
                .HasForeignKey(d => d.QuizId);

        }
    }
}
