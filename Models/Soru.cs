using Microsoft.AspNetCore.Mvc;
using SurucuKursu.MetaData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurucuKursu.Models;
[ModelMetadataType(typeof(SoruMetaData))]
public partial class Soru
{
    public long Id { get; set; }

    public long? TipId { get; set; }

    public string Ad { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public string Metin { get; set; } = null!;

    public string? Cevap { get; set; }

    public long? Visibility { get; set; }

    public string? Telefon { get; set; }
}
