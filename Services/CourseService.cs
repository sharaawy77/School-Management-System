using Microsoft.EntityFrameworkCore;
using School_Management_System.Data;
using School_Management_System.Models;

namespace School_Management_System.Services
{
    public class CourseService : IRepoService<Course>
    {
        private readonly ApplicationDbContext context;

        public CourseService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<int> AddAsync(Course model)
        {
            int numberOfRowsAffected = -1;
            try
            {
                await context.Courses.AddAsync(model);
                numberOfRowsAffected = await context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
            return numberOfRowsAffected;
        }

        public async Task<int> DeleteAsync(int id)
        {
            int numberOfRowsAffected = -1;
            try
            {
                context.Courses.Remove(await context.Courses.FindAsync(id));
                numberOfRowsAffected = await context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
            return numberOfRowsAffected;
        }

        public async Task<Course> GetValueAsync(int id)
        {
            Course course = new Course();
            try
            {
                course = await context.Courses.FindAsync(id);


            }
            catch (Exception)
            {

                throw;
            }
            return course;
        }

        public async Task<List<Course>> GetValuesAsync()
        {
            var courses = new List<Course>();
            try
            {
                courses = await context.Courses.ToListAsync();


            }
            catch (Exception)
            {

                throw;
            }
            return courses;
        }

        public async Task<int> UpdateAsync(Course model)
        {
            int numberOfRowsAffected = -1;
            try
            {
                var course = await context.Courses.FindAsync(model.CourseId);
                course.Name=model.Name;
                numberOfRowsAffected = await context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
            return numberOfRowsAffected;
        }
    }
}
