using Microsoft.EntityFrameworkCore;
using School_Management_System.Data;
using School_Management_System.Models;

namespace School_Management_System.Services
{
    public class ExamQuestionsService : IRepoService<ExamQuestion>
    {
        private readonly ApplicationDbContext context;

        public ExamQuestionsService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<int> AddAsync(ExamQuestion model)
        {
            int numberOfRowsAffected = -1;
            try
            {
                await context.ExamQuestions.AddAsync(model);
                numberOfRowsAffected = await context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
            return numberOfRowsAffected;
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ExamQuestion> GetValueAsync(int id)
        {
            ExamQuestion TA = new ExamQuestion();
            try
            {
                TA = await context.ExamQuestions.Include(T => T.Question).FirstOrDefaultAsync(TA => TA.ExamId == id);


            }
            catch (Exception)
            {

                throw;
            }
            return TA;
        }

        public async Task<List<ExamQuestion>> GetValuesAsync()
        {
            var TAS = new List<ExamQuestion>();
            try
            {
                TAS = await context.ExamQuestions.Include(T => T.Question).ToListAsync();


            }
            catch (Exception)
            {

                throw;
            }
            return TAS;
        }

        public Task<int> UpdateAsync(ExamQuestion model)
        {
            throw new NotImplementedException();
        }
    }
}
