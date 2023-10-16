using Microsoft.EntityFrameworkCore;
using School_Management_System.Data;
using School_Management_System.Models;

namespace School_Management_System.Services
{
    public class StudentAttendanceService : IRepoService<StudentsAttendance>
    {
        private readonly ApplicationDbContext context;

        public StudentAttendanceService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<int> AddAsync(StudentsAttendance model)
        {
            int numberOfRowsAffected = -1;
            try
            {
                await context.StudentsAttendances.AddAsync(model);
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
                context.StudentsAttendances.Remove(await context.StudentsAttendances.FindAsync(id));
                numberOfRowsAffected = await context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
            return numberOfRowsAffected;
        }

        public async Task<StudentsAttendance> GetValueAsync(int id)
        {
            StudentsAttendance TA = new StudentsAttendance();
            try
            {
                TA = await context.StudentsAttendances.Include(T => T.Student).FirstOrDefaultAsync(TA => TA.AttendanceId == id);


            }
            catch (Exception)
            {

                throw;
            }
            return TA;
        }

        public  async Task<List<StudentsAttendance>> GetValuesAsync()
        {
            var TAS = new List<StudentsAttendance>();
            try
            {
                TAS = await context.StudentsAttendances.Include(T => T.Student).ToListAsync();


            }
            catch (Exception)
            {

                throw;
            }
            return TAS;
        }

        public async Task<int> UpdateAsync(StudentsAttendance model)
        {
            int numberOfRowsAffected = -1;
            try
            {
                var TA = await context.StudentsAttendances.FindAsync(model.AttendanceId);
                TA.Attendant = model.Attendant;
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
