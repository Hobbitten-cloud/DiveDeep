namespace DiveDeepProject.Models.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public double PricePerDay { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        public List<BCD>? BCDs { get; set; }
        public List<Flipper>? Flippers { get; set; }
        public List<DivingSuit>? DivingSuits { get; set; }
        public List<Tank>? Tanks { get; set; }
        public List<SnorkelSet>? SnorkelSets { get; set; }
        public List<Regulatorset>? Regulatorsets { get; set; }

    }
}
