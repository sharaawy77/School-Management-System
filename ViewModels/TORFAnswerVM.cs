using School_Management_System.Models;

namespace School_Management_System.ViewModels
{
    public class TORFAnswerVM
    {
        public int AnswerId { get; set; }

        public int QuestionId { get; set; }
        public bool TORFanswer { set; get; }
        public string Question { set; get; }
        public TORFAnswerVM()
        {

        }
        public TORFAnswerVM(T_OR_F_Answer model)
        {
            AnswerId = model.AnswerId;
            QuestionId = model.QuestionId;
            TORFanswer = model.TOrFAnswer;
            Question = model.Question.Body;
        }
        public T_OR_F_Answer ConverVM(TORFAnswerVM model)
        {
            return new T_OR_F_Answer()
            {
                AnswerId = model.AnswerId,
                QuestionId = model.QuestionId,
                TOrFAnswer = model.TORFanswer
            };
        }
    }
}
