using School_Management_System.Models;

namespace School_Management_System.ViewModels
{
    public class ExamQuestionVM
    {
        public string Question { set; get; }
        public int ExamId { get; set; }
        public ExamQuestionVM()
        {
            
        }
        public ExamQuestionVM(ExamQuestion model)
        {
            Question = model.Question.Body;
            ExamId=model.ExamId;
        }
    }
}
