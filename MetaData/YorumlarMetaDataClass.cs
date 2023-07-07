using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SurucuKursu.MetaData
{
	public class YorumlarMetaDataClass
	{
		[Key]
		public long Id { get; set; }
		
		public long? ParentId { get; set; }

		//[Range(minimum:2, maximum: 30, ErrorMessage ="Adınız en az 2 en fazla 30 karakter olmalı")]
		public string Ad { get; set; } = null!;

		[DataType(DataType.EmailAddress), Required, DisplayName("E-Mail")]
		public string Mail { get; set; } = null!;

		public string? Metin { get; set; }

		public long? Yildiz { get; set; }

		public long? Visibility { get; set; }
	}
}
