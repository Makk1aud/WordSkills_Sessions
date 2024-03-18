using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class MedicalActiveType
{
    public int MedicalTypeId { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<MedicalActivite> MedicalActivites { get; set; } = new List<MedicalActivite>();
}
