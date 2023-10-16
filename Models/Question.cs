using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_Management_System.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; } 
        public string Header { set; get; }
        public string Body { get; set; }
        public int Mark { set; get; }
        public string MsqRAns { set; get; }
        public bool TORFRAns { set; get; }
        public virtual ICollection<ExamQuestion> Exams { get; set; } = new HashSet<ExamQuestion>();
      
        public virtual ICollection<Answer> Answers { get;set; }=new HashSet<Answer>();  
    }
}
