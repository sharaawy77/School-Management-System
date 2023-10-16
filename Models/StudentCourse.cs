namespace School_Management_System.Models
{
    public class StudentCourse
    {
        public int CourseId { get; set; }
        public int StudentId { set; get; }
        public virtual Course Course { get; set; }
        public virtual Student Student { set; get; }
                 
    }
}
