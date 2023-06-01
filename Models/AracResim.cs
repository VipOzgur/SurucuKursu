using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurucuKursu.Models;

public partial class AracResim
{
    [ForeignKey("Araclar")]
    public long Id { get; set; }

    
    public long ParentId { get; set; }

    public string? Resim { get; set; } = null;

    public virtual Araclar? Parent { get; set; } = null;

    [NotMapped]
    public IFormFile? ImgFile { get; set; }
}
