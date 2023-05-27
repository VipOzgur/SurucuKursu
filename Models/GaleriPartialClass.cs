using System.ComponentModel.DataAnnotations.Schema;

namespace SurucuKursu.Models
{
    public partial class Galeri
    {
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
