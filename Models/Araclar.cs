using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace SurucuKursu.Models;

public partial class Araclar
{    public long Id { get; set; }

    public string Adı { get; set; } = null!;

    public string? Plaka { get; set; }

    public virtual List<AracResim> AracResims { get; set; } = new List<AracResim>();

    public List<AracResim> GetAracResims(long aracId)
    {
        using (var context = new SkContext())
        {
            var aracResims = context.AracResims
                                    .Where(r => r.ParentId == aracId)
                                    .ToList();

            return aracResims;
        }
    }


}
