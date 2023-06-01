using System.ComponentModel.DataAnnotations.Schema;

namespace SurucuKursu.Models
{
    public partial class Ehliyet
    {
        [NotMapped]
        public  IFormFile ResimFile{ get; set; }
    }
}
