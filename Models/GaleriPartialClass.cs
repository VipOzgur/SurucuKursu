using System.ComponentModel.DataAnnotations.Schema;

namespace SurucuKursu.Models
{
    public partial class Galeri
    {
        [NotMapped]
        public List<IFormFile> ImageFile { get; set; }
    }
}
