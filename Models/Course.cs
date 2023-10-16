using System.ComponentModel.DataAnnotations;

namespace School_Management_System.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        [Required]
        public string Name { set; get; }
        public virtual ICollection<Teacher> Teachers { get; set; }=new HashSet<Teacher>();
        public virtual ICollection<StudentCourse> Students { get; set; } = new HashSet<StudentCourse>();
        
    }
}
