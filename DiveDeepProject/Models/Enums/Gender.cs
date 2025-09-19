using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiveDeepProject.Models.Enums
{
	public enum Gender
	{
		[Display(Name = "Herre")]
		Male,

		[Display(Name = "Dame")]
		Female,
	}
}
