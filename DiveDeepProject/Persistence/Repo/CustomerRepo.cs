using DiveDeepProject.Persistence.IRepo;
using DiveDeepProject.Models.Domain;
using DiveDeepProject.Data;
namespace DiveDeepProject.Persistence.Repo
{
    public class CustomerRepo : IGetRepo<Customer>, ICreateRepo<Customer>
    {
        private List<Customer> _customers;
		private readonly DiveDeepContext _context;
		public CustomerRepo(DiveDeepContext context)
		{
			_customers = new List<Customer>();
            _context = context;
		}
		public Customer Create(Customer item)
        {
			if (item == null) return null;

			//item.Id = _customers.Any() ? _customers.Max(x => x.Id) + 1 : 1;

			_customers.Add(item);
            _context.Customers.Add(item);
			_context.SaveChanges();
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
