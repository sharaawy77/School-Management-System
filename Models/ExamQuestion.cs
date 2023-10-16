using System.ComponentModel.DataAnnotations.Schema;

namespace School_Management_System.Models
{
    public class ExamQuestion
    {
        public int QuestionId { get; set; }
        public virtual Question Question { set; get; }

        public int ExamId { get; set; }

        public virtual Exam Exam { set; get; }
        public ICollection<Student> students { set; get; }=new HashSet<Student>();
    }
}
