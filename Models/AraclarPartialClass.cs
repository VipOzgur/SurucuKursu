using System.ComponentModel.DataAnnotations.Schema;

namespace SurucuKursu.Models
{
    public partial class Araclar
    {

        [NotMapped]
        public List<IFormFile> ImageFile { get; set; }

        [NotMapped]
        public List<AracResim>? Resim { get; set; } = null;
    }
}
