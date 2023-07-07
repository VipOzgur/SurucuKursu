using System.ComponentModel.DataAnnotations.Schema;

namespace SurucuKursu.Models
{
    public partial class Egitmenler
    {
        [NotMapped]
        public IFormFile? ImgFile { get; set; }
    }
}
