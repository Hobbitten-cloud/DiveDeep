namespace DiveDeepProject.Models.Domain
{
	public class UnavailableDates
	{
		public int id { get; set; }
		public DateOnly UnavailableDate { get; set; }

		public int ProductId { get; set; }
	}
}
