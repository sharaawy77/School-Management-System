using Microsoft.EntityFrameworkCore;
using School_Management_System.Data;
using School_Management_System.Models;

namespace School_Management_System.Services
{
    public class MSQAnswerService : IRepoService<MSQAnswer>
    {
        private readonly ApplicationDbContext context;

        public MSQAnswerService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<int> AddAsync(MSQAnswer model)
        {
            int numberOfRowsAffected = -1;
            try
            {
                await context.MSQAnswers.AddAsync(model);
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
                context.MSQAnswers.Remove(await context.MSQAnswers.FindAsync(id));
                numberOfRowsAffected = await context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
            return numberOfRowsAffected;
        }

        public async Task<MSQAnswer> GetValueAsync(int id)
        {
            MSQAnswer Ans = new MSQAnswer();
            try
            {
                Ans = await context.MSQAnswers.Include(T => T.Question).FirstOrDefaultAsync(TA => TA.AnswerId == id);


            }
            catch (Exception)
            {

                throw;
            }
            return Ans;
        }

        public async Task<List<MSQAnswer>> GetValuesAsync()
        {
            var Anss = new List<MSQAnswer>();
            try
            {
                Anss = await context.MSQAnswers.Include(T => T.Question).ToListAsync();


            }
            catch (Exception)
            {

                throw;
            }
            return Anss;
        }

        public Task<int> UpdateAsync(MSQAnswer model)
        {
            throw new NotImplementedException();
        }
    }
}
