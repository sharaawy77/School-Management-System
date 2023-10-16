using Microsoft.EntityFrameworkCore;
using School_Management_System.Data;
using School_Management_System.Models;

namespace School_Management_System.Services
{
    public class TeacherService : IRepoService<Teacher>
    {
        private readonly ApplicationDbContext context;

        public TeacherService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<int> AddAsync(Teacher model)
        {
            int numberOfRowsAffected = -1;
            try
            {
                await context.Teachers.AddAsync(model);
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
                context.Teachers.Remove(await context.Teachers.FindAsync(id));
                numberOfRowsAffected = await context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
            return numberOfRowsAffected;
        }

        public async Task<Teacher> GetValueAsync(int id)
        {
            Teacher teacher = new Teacher();
            try
            {
                teacher = await context.Teachers.FindAsync(id);


            }
            catch (Exception)
            {

                throw;
            }
            return teacher;
        }

        public async Task<List<Teacher>> GetValuesAsync()
        {
            var teachers = new List<Teacher>();
            try
            {
                teachers = await context.Teachers.Include(t=>t.course).ToListAsync();


            }
            catch (Exception)
            {

                throw;
            }
            return teachers;
        }

        public async Task<int> UpdateAsync(Teacher model)
        {
            int numberOfRowsAffected = -1;
            try
            {
                var teacher = await context.Teachers.FindAsync(model.TeacherId);
                teacher.TeacherId = model.TeacherId;
                teacher.email = model.email;
                teacher.BirDate = model.BirDate;
                teacher.Age = model.Age;
                teacher.JoinDate = model.JoinDate;
                teacher.Salary = model.Salary;
                teacher.ProfilePic = model.ProfilePic;
                teacher.course = model.course;
                teacher.MobileNum = model.MobileNum;
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
