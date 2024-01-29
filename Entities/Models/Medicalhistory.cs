using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Medicalhistory
{
    public int MedicalHistoryId { get; set; }

    public int MedicalCardId { get; set; }

    public string Diagnose { get; set; } = null!;

    public virtual Medicalcard MedicalCard { get; set; } = null!;
}
