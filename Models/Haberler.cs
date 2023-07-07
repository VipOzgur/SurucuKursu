using Microsoft.AspNetCore.Mvc;
using SurucuKursu.MetaData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurucuKursu.Models;
[ModelMetadataType(typeof(HaberlerMetaDataClass))]
public partial class Haberler
{
    public long Id { get; set; }

    public string Baslik { get; set; } = null!;

    public string Metin { get; set; } = null!;

    public string? Medya { get; set; }

    public string? Tarih { get; set; }
}
