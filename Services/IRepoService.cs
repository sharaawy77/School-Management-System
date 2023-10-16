namespace School_Management_System.Services
{
    public interface IRepoService<T>
    {
        public Task<List<T>> GetValuesAsync();
        public Task<T> GetValueAsync(int id);
        public Task<int> UpdateAsync(T model);
        public Task<int> DeleteAsync(int id);
        public Task<int> AddAsync(T model);
    }
}
