using School_Management_System.Models;
using System.ComponentModel.DataAnnotations;

namespace School_Management_System.ViewModels
{
    public class StudentVM
    {
        public int StudentId { set; get; }
        [Required]

        public string name { set; get; }
        [Required]

        public string email { set; get; }
        [Required]

        public DateTime BirDate { set; get; }
        [Required]

        public int Age;
        [Required]

        public DateTime JoinDate { set; get; }
        [Required]

        public string Grade { set; get; }
        [Required]

        public string Address { set; get; }
        [Required]

        public string MobileNum { set; get; }

        public StudentVM()
        {
            
        }
        public StudentVM(Student model)
        {
            StudentId = model.StudentId;
            name = model.name;
            email = model.email;
            BirDate = model.BirDate;
            Age = DateTime.Now.Year-model.BirDate.Year;
            JoinDate = model.JoinDate;
            Grade = model.Grade;
            Address = model.Address;
            MobileNum = model.MobileNum;

        }
        public Student ConvertVM(StudentVM model)
        {
            return new Student()
            {
                StudentId = model.StudentId,
                name = model.name,
                email=model.email,
                BirDate = model.BirDate,
                Age = DateTime.Now.Year-BirDate.Year,
                JoinDate = model.JoinDate,
                Grade = model.Grade,
                Address = model.Address,
                MobileNum = model.MobileNum,

            };
        }

    }
}
