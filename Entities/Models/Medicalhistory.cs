using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class MedicalHistory
{
    public int MedicalHistoryId { get; set; }

    public int MedicalCardId { get; set; }

    public string Diagnose { get; set; } = null!;

    public virtual MedicalCard MedicalCard { get; set; } = null!;
}
