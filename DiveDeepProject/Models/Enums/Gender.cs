using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DiveDeepProject.Models.Enums
{
	public enum Gender
	{
		[Display(Name = "Herre")]
		Male,

		[Display(Name = "Dame")]
		Female
	}
}
