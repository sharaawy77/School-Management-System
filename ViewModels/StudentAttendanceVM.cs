using School_Management_System.Models;
using System.ComponentModel.DataAnnotations;

namespace School_Management_System.ViewModels
{
    public class StudentAttendanceVM
    {
        public int AttendanceId { set; get; }
        public string StudentName { set; get; }
        public DateTime Date { set; get; } = DateTime.Now;
        [Required]
        public bool Attendant { set; get; }
        public int StudentId { set; get; }
        public StudentAttendanceVM()
        {

        }
        public StudentAttendanceVM(StudentsAttendance model)
        {
            StudentName = model.Student.name;
            Date = model.Date;
            Attendant = model.Attendant;
            AttendanceId = model.AttendanceId;
            StudentId = model.StudentId;
        }
        public TeacherAttendance ConvertVM(TeacherAttendanceVM model)
        {
            return new TeacherAttendance()
            {
                Date = model.Date,
                Attendant = model.Attendant,
                TeacherId = model.TeacherId,
                AttendanceId = model.AttendanceId,
            };
        }
    }
}
