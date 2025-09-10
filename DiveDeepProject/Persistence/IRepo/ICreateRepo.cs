namespace DiveDeepProject.Persistence.IRepo
{
    public interface ICreateRepo<T> : IRepo<T>
    {
        public T Create(T item);
    }
}
