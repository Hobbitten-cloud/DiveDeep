namespace DiveDeepProject.Persistence.IRepo
{
    public interface IUpdateRepo<T> : IRepo<T>
    {
        public void Update(T UpdateItem);
    }
}
