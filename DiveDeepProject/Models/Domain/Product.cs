namespace DiveDeepProject.Models.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public double PricePerDay { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        public BCD BCD { get; set; } = null!;
        public DivingSuit DivingSuit { get; set; } = null!;
        public Flipper Flipper { get; set; } = null!;
        public Regulatorset Regulatorset { get; set; } = null!;
        public SnorkelSet SnorkelSet { get; set; } = null!;
        public Tank Tank { get; set; } = null!;
    }
}
