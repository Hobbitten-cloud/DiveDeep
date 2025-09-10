namespace DiveDeepProject.Persistence.IRepo
{
    public interface IDeleteRepo<T> : IRepo<T>
    {
        public void Delete(T item);
    }
}
