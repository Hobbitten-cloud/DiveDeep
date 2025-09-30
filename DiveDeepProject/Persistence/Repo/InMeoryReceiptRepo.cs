using DiveDeepProject.Models.Domain;

namespace DiveDeepProject.Persistence.Repo
{
    public class InMemoryReceiptRepo
    {
        private static List<Receipt> receipts = new List<Receipt>
    {
        new Receipt
        {
            Id = 1,
            PickupDate = DateTime.Now,
            ReturnDate = new DateTime(2025, 9, 30, 11, 30, 0),
            Products = new List<Product>
            {
                new Product { Id = 1, Brand = "Dykkerdragt" },
                new Product { Id = 2, Brand = "BCD" }
            },
            Total = 499.95,
            Comment = "Test booking",
            HasDivingCertificat = true,
            AcceptedTerms = true
        },
                new Receipt
        {
            Id = 2,
            PickupDate = new DateTime(1000, 1, 1, 1, 40, 0),
            ReturnDate = new DateTime(2025, 12, 24, 12, 24, 0),
            Products = new List<Product>
            {
                new Product { Id = 1, Brand = "Din mor" },
                new Product { Id = 2, Brand = "Din far" }
            },
            Total = 10319238,
            Comment = "Test booking2",
            HasDivingCertificat = true,
            AcceptedTerms = true
        }
    };

        public List<Receipt> GetAll()
        {
            return receipts;
        }

        public static void Delete(int id)
        {
            receipts.RemoveAll(x => x.Id == id);
        }
    }
}
