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
            _receipts = new List<Receipt>();
			
		}


		public ReceiptRepo()
        {
            _receipts = new List<Receipt>();
        }
        public Receipt Create(Receipt item)
        {
			if (item == null) return null;



			//If products or packages are from another context, we need to attach them to this context,
			//otherwise we get an error as it tries to insert product into the database again
			if (item.Products != null)
			{
				foreach (var prod in item.Products)
				{
					//Attach Marks the product as unchainged if it already exists in the database
					_context.Attach(prod);
					
				}
			}

			if (item.Packages != null)
			{
				foreach (var pkg in item.Packages)
				{
					_context.Attach(pkg);
				}
			}


			_receipts.Add(item);
			_context.Receipts.Add(item);
            _context.SaveChanges();
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
