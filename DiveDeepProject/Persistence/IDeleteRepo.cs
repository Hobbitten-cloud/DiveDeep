namespace DiveDeepProject.Persistence
{
    public interface IDeleteRepo<T> : IRepo<T>
    {
        public void Delete(T item);
    }
}
