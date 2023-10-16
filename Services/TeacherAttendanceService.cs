using Microsoft.EntityFrameworkCore;
using School_Management_System.Data;
using School_Management_System.Models;

namespace School_Management_System.Services
{
    public class TeacherAttendanceService : IRepoService<TeacherAttendance>
    {
        private readonly ApplicationDbContext context;

        public TeacherAttendanceService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<int> AddAsync(TeacherAttendance model)
        {
            int numberOfRowsAffected = -1;
            try
            {
                await context.TeacherAttendances.AddAsync(model);
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
                context.TeacherAttendances.Remove(await context.TeacherAttendances.FindAsync(id));
                numberOfRowsAffected = await context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
            return numberOfRowsAffected;
        }

        public async Task<TeacherAttendance> GetValueAsync(int id)
        {
            TeacherAttendance TA = new TeacherAttendance();
            try
            {
                TA = await context.TeacherAttendances.Include(T=>T.Teacher).FirstOrDefaultAsync(TA=>TA.AttendanceId==id);


            }
            catch (Exception)
            {

                throw;
            }
            return TA;
        }

        public async Task<List<TeacherAttendance>> GetValuesAsync()
        {
            var TAS = new List<TeacherAttendance>();
            try
            {
                TAS = await context.TeacherAttendances.Include(T=>T.Teacher).ToListAsync();


            }
            catch (Exception)
            {

                throw;
            }
            return TAS;
        }

        public async Task<int> UpdateAsync(TeacherAttendance model)
        {
            int numberOfRowsAffected = -1;
            try
            {
                var TA = await context.TeacherAttendances.FindAsync(model.AttendanceId);
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
