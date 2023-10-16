namespace School_Management_System.FiileService
{
    public interface IFileService
    {
        public Tuple<int, string> SaveImage(IFormFile file);
        public bool DeleteImage(string fileName);
    }
}
