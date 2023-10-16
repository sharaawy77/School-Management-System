using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_Management_System.Models
{
    public class Student
    {
        [Key]
        public int StudentId { set; get; }
        [Required]

        public string name { set; get; }
        [Required]

        public string email { set; get; }
        [Required]

        public DateTime BirDate { set; get; }
        [Required]

        public int Age;
        [Required]

        public DateTime JoinDate { set; get; }
        [Required]

        public string Grade { set; get; }
        [Required]

        public string Address { set; get; }
        [Required]
        public string ProfilePic { set; get; }
        [Required]

        public string MobileNum { set; get; }
        [ForeignKey(name: "ExamQuestionId")]

        public int? ExamQuestionId { set; get; }
        public virtual ExamQuestion Exam { set; get; }
        public virtual StudentsAttendance Attendance { set; get; }
        public virtual ICollection<StudentCourse> Courses { get; set; } = new HashSet<StudentCourse>();


    }
}
