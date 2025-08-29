namespace DiveDeepProject.Persistence
{
    public interface IUpdateRepo<T> : IRepo<T>
    {
        public void Update(T UpdateItem);
    }
}
