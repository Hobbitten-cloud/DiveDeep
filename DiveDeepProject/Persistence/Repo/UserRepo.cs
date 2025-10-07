using DiveDeepProject.Persistence.IRepo;
using DiveDeepProject.Models.Domain;
using DiveDeepProject.Data;
namespace DiveDeepProject.Persistence.Repo
{
    public class UserRepo : IGetRepo<ApplicationUser>, ICreateRepo<ApplicationUser>
    {
        private List<ApplicationUser> _users;
		private readonly DiveDeepContext _context;
		public UserRepo(DiveDeepContext context)
		{
			
            _context = context;
			_users = GetAll();
		}
		public ApplicationUser Create(ApplicationUser item)
        {
			if (item == null) return null;

			//item.Id = _customers.Any() ? _customers.Max(x => x.Id) + 1 : 1;

			_users.Add(item);
            _context.AspNetUsers.Add(item);
			_context.SaveChanges();
			return item;
        }

        public ApplicationUser Get(string Id)
        {
            return _context.AspNetUsers.ToList().Find(c => c.Id == Id);
        }

        public List<ApplicationUser> GetAll()
        {
            return _context.AspNetUsers.ToList();
		}

        public ApplicationUser Get(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
