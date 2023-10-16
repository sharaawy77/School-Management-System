using School_Management_System.Models;
using System.ComponentModel.DataAnnotations;

namespace School_Management_System.ViewModels
{
    public class CourseVM
    {
        public int CourseId { get; set; }
        [Required]
        public string Name { set; get; }
       
        

        public CourseVM()
        {

        }
        public CourseVM(Course model)
        {
            CourseId = model.CourseId;
            Name = model.Name;
            
           

        }
        public Course ConverVM(CourseVM model)
        {
            return new Course()
            {
                CourseId = model.CourseId,
                Name = model.Name,
            };
        }
    }
}
