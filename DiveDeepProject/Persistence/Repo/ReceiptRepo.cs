using DiveDeepProject.Data;
using DiveDeepProject.Models.Domain;
using DiveDeepProject.Persistence.IRepo;

namespace DiveDeepProject.Persistence.Repo
{
    public class ReceiptRepo : ICreateRepo<Receipt>, IGetRepo<Receipt>, IUpdateRepo<Receipt>
	{
        private List<Receipt> _receipts;

        private readonly DiveDeepContext _context;

		public ReceiptRepo(DiveDeepContext context)
		{
			_context = context;
			
		}


		public ReceiptRepo()
        {
            _receipts = new List<Receipt>();
        }   
        public Receipt Create(Receipt item)
        {
            _context.Add(item);
			return item;
        }

        public Receipt Get(int Id)
        {
            return _receipts.Find(r => r.Id == Id);
        }

        public List<Receipt> GetAll()
        {
            return _receipts;
        }

		public void Update(Receipt UpdateItem)
		{
            var receit = Get(UpdateItem.Id);
			receit = UpdateItem;
		}

        
	}
}
