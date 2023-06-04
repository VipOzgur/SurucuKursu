using SurucuKursu.MetaData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurucuKursu.Models;
[MetadataType(typeof(AracResimMetaDataClass))]
public partial class AracResim
{
    public long Id { get; set; }

    public long ParentId { get; set; }

    public string Resim { get; set; } = null!;

    public virtual Araclar Parent { get; set; } = null!;

	[NotMapped]
	public IFormFile? ImgFile { get; set; }
}
