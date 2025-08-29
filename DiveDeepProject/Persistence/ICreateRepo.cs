namespace DiveDeepProject.Persistence
{
    public interface ICreateRepo<T> : IRepo<T>
    {
        public T Create(T item);
    }
}
