using System.ComponentModel.DataAnnotations.Schema;

namespace SurucuKursu.Models
{
    public partial class Araclar
    {

        [NotMapped]
        public List<IFormFile> ImageFile { get; set; }

        [NotMapped]
        public List<AracResim>? Resim { get; set; } = null;

		public List<AracResim> GetAracResims(long aracId)
		{
			using (var context = new SkContext())
			{
				var aracResims = context.AracResims
										.Where(r => r.ParentId == aracId)
										.ToList();

				return aracResims;
			}
		}
	}
}
