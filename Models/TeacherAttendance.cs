using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace School_Management_System.Models
{
    public class TeacherAttendance
    {
        [Key]
        public int AttendanceId { set; get; }
        [Required]
        public DateTime Date { set; get; }= DateTime.Now;
        [Required]
        public bool Attendant { set; get; }
        public int TeacherId { set; get; }
        [ForeignKey(name: "TeacherId")]
        public virtual Teacher Teacher { set; get; }
        
    }
}
