using System.ComponentModel.DataAnnotations.Schema;

namespace SurucuKursu.Models
{
	public partial class Yorumlar
	{
        [NotMapped]
        public bool IsPosted { get; set; }
    }
}
