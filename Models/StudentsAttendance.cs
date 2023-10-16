using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_Management_System.Models
{
    public class StudentsAttendance
    {
        [Key]
        public int AttendanceId { set;get; }
        [Required]
        public DateTime Date { set;get; }
        [Required]
        public bool Attendant { set; get; }
        [ForeignKey(name: "StudentId")]
        public int StudentId { set; get; }

        public virtual Student Student { set; get; }
    }
}
