using School_Management_System.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_Management_System.ViewModels
{
    public class MSQAnswerVM
    {
        public int AnswerId { get; set; }
        
        public int QuestionId { get; set; }
        public string MSQanswer { set; get; }
        public string Question { set; get; }
        public MSQAnswerVM()
        {
            
        }
        public MSQAnswerVM(MSQAnswer model)
        {
            AnswerId = model.AnswerId;
            QuestionId=model.QuestionId;
            MSQanswer = model.MSQanswer;
            Question = model.Question.Body;
        }
        public MSQAnswer ConverVM(MSQAnswerVM model)
        {
            return new MSQAnswer()
            {
                AnswerId = model.AnswerId,
                QuestionId = model.QuestionId,
                MSQanswer = model.MSQanswer
            };
        }

    }
}
