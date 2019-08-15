using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class QuestionAnswerMap : EntityTypeConfiguration<QuestionAnswer>
    {
        public QuestionAnswerMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Question)
                .IsRequired();

            this.Property(t => t.ScoloarId)
                .HasMaxLength(10);

            this.Property(t => t.EmailId)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.KeyWords)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("QuestionAnswers");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Question).HasColumnName("Question");
            this.Property(t => t.Answer).HasColumnName("Answer");
            this.Property(t => t.ScoloarId).HasColumnName("ScoloarId");
            this.Property(t => t.TypeId).HasColumnName("TypeId");
            this.Property(t => t.Count).HasColumnName("Count");
            this.Property(t => t.EmailId).HasColumnName("EmailId");
            this.Property(t => t.IsVisible).HasColumnName("IsVisible");
            this.Property(t => t.AnswerDate).HasColumnName("AnswerDate");
            this.Property(t => t.SetDate).HasColumnName("SetDate");
            this.Property(t => t.EntryDate).HasColumnName("EntryDate");
            this.Property(t => t.IsSelfInitiative).HasColumnName("IsSelfInitiative");
            this.Property(t => t.IsFrequentAsk).HasColumnName("IsFrequentAsk");
            this.Property(t => t.KeyWords).HasColumnName("KeyWords");

            // Relationships
            this.HasRequired(t => t.QuestionType)
                .WithMany(t => t.QuestionAnswers)
                .HasForeignKey(d => d.TypeId);

        }
    }
}
