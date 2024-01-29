using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Hospital
{
    public int HospitalId { get; set; }

    public string Title { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<Hospitalisation> Hospitalisations { get; set; } = new List<Hospitalisation>();
}
