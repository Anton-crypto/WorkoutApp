namespace WorkoutApi.Manager
{
    public interface IFileManager <T> where T : class
    {
        public (bool,string) Save(T file);
        public string Delete();

    }
}
