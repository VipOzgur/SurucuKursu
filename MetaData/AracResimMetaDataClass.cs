using SurucuKursu.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurucuKursu.MetaData
{
	public class AracResimMetaDataClass
	{
		[ForeignKey("Araclar")]
		public long Id { get; set; }


		public long ParentId { get; set; }

		public string? Resim { get; set; } = null;

		public virtual Araclar? Parent { get; set; } = null;

	}
}
