using School_Management_System.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_Management_System.ViewModels
{
    public class TeacherVM
    {
        public int TeacherId { set; get; }
        public string Name { set; get; }
        public int CourseId { set; get; }
        public string Couree { set; get; }
        
        public double Salary { set; get; }
        [Required]

        public string Address { set; get; }
        [Required]

        public string MobileNum { set; get; }
        public string email { set; get; }
        [Required]

        public DateTime BirDate { set; get; }
        public string PicUrl { set; get; }
        [Required]
        public IFormFile ProfilePic { set; get; }
        [Required]

        public int Age;
        [Required]

        public DateTime JoinDate { set; get; }
        public int AttendanceId { set; get; }

        public TeacherVM()
        {
            
        }
        public TeacherVM(Teacher model)
        {
            TeacherId = model.TeacherId;
            Name = model.Name;
            email = model.email;
            Couree = model.course.Name;  
            Salary = model.Salary;
            Address = model.Address;
            MobileNum = model.MobileNum;
            BirDate = model.BirDate;
            Age = DateTime.Now.Year - BirDate.Year;
            JoinDate = model.JoinDate;
            PicUrl = model.ProfilePic;
            CourseId = model.CourseId;
            
        }
        public Teacher ConvertVM(TeacherVM model)
        {
            return new Teacher()
            {
                TeacherId = model.TeacherId,
                Name = model.Name,
                email = model.email,
                CourseId=model.CourseId,
                Salary = model.Salary,
                Address = model.Address,
                MobileNum = model.MobileNum,
                BirDate = model.BirDate,
                Age = DateTime.Now.Year - BirDate.Year,
                JoinDate = model.JoinDate,
                ProfilePic = model.PicUrl,
               
            };
        }
    }
}
