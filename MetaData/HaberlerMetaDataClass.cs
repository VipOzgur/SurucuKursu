using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace SurucuKursu.MetaData
{
	public class HaberlerMetaDataClass
	{
		public long Id { get; set; }
        [Required]
		public string Baslik { get; set; } = null!;

		public string Metin { get; set; } = null!;

		[AllowHtml]
		public string? Medya { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string? Tarih { get; set; }
	}
}
