using System.Web.Mvc;

namespace SurucuKursu.MetaData
{
	public class HaberlerMetaDataClass
	{
		public long Id { get; set; }

		public string Baslik { get; set; } = null!;

		public string Metin { get; set; } = null!;

		[AllowHtml]
		public string? Medya { get; set; }

		public string? Tarih { get; set; }
	}
}
