using System.ComponentModel.DataAnnotations;

namespace School_Management_System.Models
{
    public class Exam
    {
        [Key]
        public int ExamId { get; set; }
        public DateTime ExamTime { set;get; }
        public string Grade { set; get; }
        public int ExamMark { set; get; }
        public virtual ICollection<ExamQuestion> Questions { get; set; } = new HashSet<ExamQuestion>();

    }
}
