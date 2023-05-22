using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurucuKursu.Models;

public partial class Soru
{
    [NotMapped]
    public bool ChkVisibility
    {
        get
        {
            return Visibility == 1 ? true : false;
        }
        set
        {
            Visibility = value ? 1 : 0;
        }
    }
    [NotMapped]
    public bool IsPosted { get; set; }
}
