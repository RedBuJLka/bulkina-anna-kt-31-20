using BulkinaAnnaKT_31_20.Database.Helpers;
using BulkinaAnnaKT_31_20.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulkinaAnnaKT_31_20.Database.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        private const string TableName = "cd_student";

        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
                .HasKey(p => p.StudentId)
                .HasName($"pk_{TableName}_student_id");

            builder.Property(p => p.StudentId)
                    .ValueGeneratedOnAdd();

            builder.Property(p => p.StudentId)
                .HasColumnName("student_id")
                .HasComment("ID студента");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnName("c_student_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Имя");

            builder.Property(p => p.Surname)
                .IsRequired()
                .HasColumnName("c_student_surname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Фамилия");

            builder.Property(p => p.Patronym)
                .HasColumnName("c_student_patronym")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Отчество");

            builder.Property(p => p.GroupId)
                .IsRequired()
                .HasColumnName("f_group_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("ID группы");

            builder.ToTable(TableName)
                .HasOne(p => p.Group)
                .WithMany()
                .HasForeignKey(p => p.GroupId)
                .HasConstraintName("fk_f_group_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.GroupId, $"idx_{TableName}_fk_f_group_id");

            builder.Navigation(p => p.Group)
                .AutoInclude();
        }
    }
}