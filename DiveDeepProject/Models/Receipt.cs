using DiveDeepProject.Models.Inferfaces;

namespace DiveDeepProject.Models
{
    public class Receipt
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public List<IProduct> Products { get; set; }
        public double Total { get; set; }
        public string Comment { get; set; }

        public Receipt()
        {

        }
    }
}
