using Microsoft.EntityFrameworkCore;
using School_Management_System.Data;
using School_Management_System.Models;

namespace School_Management_System.Services
{
    public class StudentService : IRepoService<Student>
    {
        private readonly ApplicationDbContext context;

        public StudentService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<int> AddAsync(Student model)
        {
            int numberOfRowsAffected = -1;
            try
            {
                await context.Students.AddAsync(model);
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
                context.Students.Remove(await context.Students.FindAsync(id));
                numberOfRowsAffected = await context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
            return numberOfRowsAffected;
        }

        public async Task<Student> GetValueAsync(int id)
        {
            Student student = new Student();
            try
            {
                student=await context.Students.FindAsync(id);
               

            }
            catch (Exception)
            {

                throw;
            }
            return student;
        }

        public async Task<List<Student>> GetValuesAsync()
        {
            var students = new List<Student>();
            try
            {
                students = await context.Students.ToListAsync();
                

            }
            catch (Exception)
            {

                throw;
            }
            return students;
        }

        public async Task<int> UpdateAsync(Student model)
        {
            int numberOfRowsAffected = -1;
            try
            {
                var student = await context.Students.FindAsync(model.StudentId);
                student.StudentId = model.StudentId;
                student.email = model.email;
                student.BirDate = model.BirDate;
                student.Age = model.Age;
                student.JoinDate = model.JoinDate;
                student.Grade = model.Grade;
                student.MobileNum = model.MobileNum;
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
