using Microsoft.EntityFrameworkCore;
using School_Management_System.Data;
using School_Management_System.Models;

namespace School_Management_System.Services
{
    public class ExamService : IRepoService<Exam>
    {
        private readonly ApplicationDbContext context;

        public ExamService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<int> AddAsync(Exam model)
        {
            int numberOfRowsAffected = -1;
            try
            {
                await context.Exams.AddAsync(model);
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
                context.Exams.Remove(await context.Exams.FindAsync(id));
                numberOfRowsAffected = await context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
            return numberOfRowsAffected;
        }

        public async Task<Exam> GetValueAsync(int id)
        {
            Exam TA = new Exam();
            try
            {
                TA = await context.Exams.Include(T => T.Questions).FirstOrDefaultAsync(TA => TA.ExamId == id);


            }
            catch (Exception)
            {

                throw;
            }
            return TA;
        }

        public async Task<List<Exam>> GetValuesAsync()
        {
            var TAS = new List<Exam>();
            try
            {
                TAS = await context.Exams.Include(T => T.Questions).ToListAsync();


            }
            catch (Exception)
            {

                throw;
            }
            return TAS;
        }

        public Task<int> UpdateAsync(Exam model)
        {
            throw new NotImplementedException();
        }
    }
}
