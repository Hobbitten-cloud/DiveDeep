using DiveDeepProject.Persistence.IRepo;
using DiveDeepProject.Models;

namespace DiveDeepProject.Persistence.Repo
{
    public class CustomerRepo : IGetRepo<Customer>, ICreateRepo<Customer>
    {
        private List<Customer> _customers;
        public Customer Create(Customer item)
        {
            _customers.Add(item);
            return item;
        }

        public Customer Get(int Id)
        {
            return _customers.Find(c => c.Id == Id);
        }

        public List<Customer> GetAll()
        {
            return _customers;
        }
    }
}
