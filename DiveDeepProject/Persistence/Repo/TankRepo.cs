using DiveDeepProject.Models;

namespace DiveDeepProject.Persistence.Repo
{
    public class TankRepo
    {
        private static List<Tank> tanks = new List<Tank> {
        new Tank
        {
            Id = 1,
            Description = "Inception",
            Brand = 2010,
            PricePerDay = 148,
            Volume = "A mind-bending thriller about dreams within dreams.",
        },
        };
    }
}
