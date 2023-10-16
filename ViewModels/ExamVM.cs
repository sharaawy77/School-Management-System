using School_Management_System.Models;

namespace School_Management_System.ViewModels
{
    public class ExamVM
    {
        public int ExamId { get; set; }
        public DateTime ExamTime { set; get; }
        public string Grade { set; get; }
        public int ExamMark { set; get; }
      





        public ExamVM()
        {
            
        }
        public ExamVM(Exam model)
        {
            ExamId = model.ExamId;
            ExamTime = model.ExamTime;
            Grade = model.Grade;
            ExamMark = model.ExamMark;
           

        }

    }
}
