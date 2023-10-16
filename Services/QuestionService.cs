using Microsoft.EntityFrameworkCore;
using School_Management_System.Data;
using School_Management_System.Models;

namespace School_Management_System.Services
{
    public class QuestionService : IRepoService<Question>
    {
        private readonly ApplicationDbContext context;

        public QuestionService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<int> AddAsync(Question model)
        {
            int numberOfRowsAffected = -1;
            try
            {
                await context.Questions.AddAsync(model);
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
                context.Questions.Remove(await context.Questions.FindAsync(id));
                numberOfRowsAffected = await context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
            return numberOfRowsAffected;
        }

        public async Task<Question> GetValueAsync(int id)
        {
            Question QA = new Question();
            try
            {
                QA = await context.Questions.Include(T => T.Answers).FirstOrDefaultAsync(TA => TA.QuestionId == id);


            }
            catch (Exception)
            {

                throw;
            }
            return QA;
        }

        public async Task<List<Question>> GetValuesAsync()
        {
            var QAS = new List<Question>();
            try
            {
                QAS = await context.Questions.Include(T => T.Answers).ToListAsync();


            }
            catch (Exception)
            {

                throw;
            }
            return QAS;
        }

        public Task<int> UpdateAsync(Question model)
        {
            throw new NotImplementedException();
        }
    }
}
