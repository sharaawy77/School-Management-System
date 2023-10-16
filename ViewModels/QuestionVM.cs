using School_Management_System.Models;

namespace School_Management_System.ViewModels
{
    public class QuestionVM
    {
        public int QuestionId { get; set; }
        public string Header { set; get; }
        public string Body { get; set; }
        public int Mark { set; get; }
        public string MsqRAns { set; get; }
        public bool TORFRAns { set; get; }
        //public List<string> MsqAns { set; get; }
        //public List<bool> TORFAns { set; get; }
        public QuestionVM()
        {
            
        }
        public QuestionVM(Question model)
        {
            QuestionId = model.QuestionId;

            Header = model.Header;
            Body = model.Body;
            Mark = model.Mark;
            MsqRAns = model.MsqRAns;
            TORFRAns = model.TORFRAns;
            
        }
        public Question ConvertVM(QuestionVM model)
        {
            return new Question()
            {
                QuestionId = model.QuestionId,
                Header = model.Header,
                Body = model.Body,
                Mark = model.Mark,
                MsqRAns = model.MsqRAns,
                TORFRAns = model.TORFRAns,
            };
        }
    }
}
