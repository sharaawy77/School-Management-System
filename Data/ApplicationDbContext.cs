using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using School_Management_System.Models;

namespace School_Management_System.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<StudentCourse>().HasKey(s => new { s.StudentId, s.CourseId });
            builder.Entity<Student>().HasMany(st => st.Courses).WithOne(SC => SC.Student);
            builder.Entity<Course>().HasMany(c => c.Students).WithOne(SC => SC.Course);


            builder.Entity<ExamQuestion>().HasKey(e => new { e.ExamId, e.QuestionId });
            builder.Entity<Exam>().HasMany(e => e.Questions).WithOne(E => E.Exam);
            builder.Entity<Question>().HasMany(q => q.Exams).WithOne(q => q.Question);
            
            
            builder.Entity<MSQAnswer>().HasBaseType<Answer>();
            builder.Entity<T_OR_F_Answer>().HasBaseType<Answer>();

            builder.Entity<Teacher>().HasOne(TA => TA.TeacherAttendance).WithOne(TA => TA.Teacher);


            builder.Entity<IdentityUser>().ToTable("Users", "Security");
            builder.Entity<IdentityRole>().ToTable("Roles", "Security");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "Security");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "Security");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "Security");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "Security");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "Security");

        }
        public virtual DbSet<Student> Students { set; get; }
        public virtual DbSet<Course> Courses { set; get; }
        public virtual DbSet<StudentCourse> StudentCourses { set; get; }
        public virtual DbSet<Teacher> Teachers { set; get; }
        public virtual DbSet<TeacherAttendance> TeacherAttendances { set; get; }
        public virtual DbSet<StudentsAttendance> StudentsAttendances { set; get; }
        public virtual DbSet<Question> Questions { set; get; }
        public virtual DbSet<MSQAnswer> MSQAnswers { set; get; } 
        public virtual DbSet<T_OR_F_Answer> T_OR_F_Answers { set; get; }
        public virtual DbSet<Exam> Exams { set; get; }
        public virtual DbSet<ExamQuestion> ExamQuestions { set; get; }
                 



    }
}