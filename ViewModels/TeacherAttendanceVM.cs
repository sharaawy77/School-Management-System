using School_Management_System.Models;
using System.ComponentModel.DataAnnotations;

namespace School_Management_System.ViewModels
{
    public class TeacherAttendanceVM
    {
        public int AttendanceId { set; get; }
        public string TeacherName { set; get; }
        public DateTime Date { set; get; } = DateTime.Now;
        [Required]
        public bool Attendant { set; get; }
        public int TeacherId { set; get; }
        public TeacherAttendanceVM()
        {
            
        }
        public TeacherAttendanceVM(TeacherAttendance model)
        {
            TeacherName = model.Teacher.Name;
            Date = model.Date;
            Attendant = model.Attendant;
            AttendanceId = model.AttendanceId;
            
        }
        public TeacherAttendance ConvertVM(TeacherAttendanceVM model)
        {
            return new TeacherAttendance()
            {
                Date=model.Date,
                Attendant=model.Attendant,
                TeacherId=model.TeacherId,
                AttendanceId=model.AttendanceId,
            };
        }

    }
}
