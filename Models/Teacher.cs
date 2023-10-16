using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_Management_System.Models
{
    public class Teacher
    {
        public int TeacherId { set;get; }
        public string Name { set;get; }
        [ForeignKey(name:"CourseId")]
        public int CourseId { set; get; }

        public virtual Course course { set;get; }
        public double Salary { set;get; }
        [Required]

        public string Address { set; get; }
        [Required]

        public string MobileNum { set; get; }
        public string email { set; get; }
        [Required]

        public DateTime BirDate { set; get; }
        [Required]
        public string ProfilePic { set; get; }
        [Required]

        public int Age;
        [Required]

        public DateTime JoinDate { set; get; }
        

        public virtual TeacherAttendance TeacherAttendance { set; get; }
    }
}
