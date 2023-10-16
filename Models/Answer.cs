using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_Management_System.Models
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }
        [ForeignKey(name: "QuestionId")]
        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }
    }
}
