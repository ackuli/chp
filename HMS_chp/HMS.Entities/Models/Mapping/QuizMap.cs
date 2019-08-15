using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class QuizMap : EntityTypeConfiguration<Quiz>
    {
        public QuizMap()
        {
            // Primary Key
            this.HasKey(t => t.QuizId);

            // Properties
            // Table & Column Mappings
            this.ToTable("Quizs");
            this.Property(t => t.QuizId).HasColumnName("QuizId");
            this.Property(t => t.PreQuizRefId).HasColumnName("PreQuizRefId");
            this.Property(t => t.StartTime).HasColumnName("StartTime");
            this.Property(t => t.Duration).HasColumnName("Duration");
            this.Property(t => t.EndTime).HasColumnName("EndTime");
            this.Property(t => t.Score).HasColumnName("Score");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
        }
    }
}
