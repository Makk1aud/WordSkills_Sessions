using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Medicalactivetype
{
    public int MedicalTypeId { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Medicalactivite> Medicalactivites { get; set; } = new List<Medicalactivite>();
}
