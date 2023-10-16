using Microsoft.EntityFrameworkCore;
using School_Management_System.Data;
using School_Management_System.Models;

namespace School_Management_System.Services
{
    public class TORFAnswerService : IRepoService<T_OR_F_Answer>
    {
        private readonly ApplicationDbContext context;

        public TORFAnswerService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<int> AddAsync(T_OR_F_Answer model)
        {
            int numberOfRowsAffected = -1;
            try
            {
                await context.T_OR_F_Answers.AddAsync(model);
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
                context.T_OR_F_Answers.Remove(await context.T_OR_F_Answers.FindAsync(id));
                numberOfRowsAffected = await context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
            return numberOfRowsAffected;
        }

        public async Task<T_OR_F_Answer> GetValueAsync(int id)
        {
            T_OR_F_Answer Ans = new T_OR_F_Answer();
            try
            {
                Ans = await context.T_OR_F_Answers.Include(T => T.Question).FirstOrDefaultAsync(TA => TA.AnswerId == id);


            }
            catch (Exception)
            {

                throw;
            }
            return Ans;
        }

        public async Task<List<T_OR_F_Answer>> GetValuesAsync()
        {
            var Anss = new List<T_OR_F_Answer>();
            try
            {
                Anss = await context.T_OR_F_Answers.Include(T => T.Question).ToListAsync();


            }
            catch (Exception)
            {

                throw;
            }
            return Anss;
        }

        public Task<int> UpdateAsync(T_OR_F_Answer model)
        {
            throw new NotImplementedException();
        }
    }
}
