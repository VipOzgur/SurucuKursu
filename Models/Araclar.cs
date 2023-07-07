using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurucuKursu.Models;
[ModelMetadataType(typeof(AraclarMetaData))]
public partial class Araclar
{
    public long Id { get; set; }

    public string Adı { get; set; } = null!;

    public string? Plaka { get; set; }

    public virtual ICollection<AracResim> AracResims { get; set; } = new List<AracResim>();
}
