namespace DiveDeepProject.Persistence.IRepo
{
    public interface IGetRepo<T> : IRepo<T>
    {
        public T Get(int Id);
        public List<T> GetAll();
    }
}
