using System.ComponentModel.DataAnnotations.Schema;

namespace SurucuKursu.Models
{
    public partial class Araclar
    {
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
