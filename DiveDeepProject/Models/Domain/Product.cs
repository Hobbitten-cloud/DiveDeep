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

        //public BCD BCD { get; set; } = null!;
        //public int BCDId { get; set; }

        //public DivingSuit DivingSuit { get; set; } = null!;
        //public int DivingSuitID { get; set; }

        //public Flipper Flipper { get; set; } = null!;
        //public int FlipperId { get; set; }

        //public Regulatorset Regulatorset { get; set; } = null!;
        //public int RegulatorsetId { get; set; }

        //public SnorkelSet SnorkelSet { get; set; } = null!;
        //public int SnorkelSetId { get; set; }

        //public Tank Tank { get; set; } = null!;
        //public int TankId { get; set; }
    }
}
