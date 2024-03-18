using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class AdmissionType
{
    public int AdmissionTypeId { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Hospitalisation> Hospitalisations { get; set; } = new List<Hospitalisation>();
}
