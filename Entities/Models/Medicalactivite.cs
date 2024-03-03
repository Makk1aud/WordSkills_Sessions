using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Medicalactivite
{
    public int MedicalActivitesId { get; set; }

    public int PatientId { get; set; }

    public int DoctorId { get; set; }

    public int MedicalTypeId { get; set; }

    public DateTime HoldingDate { get; set; }

    public string Title { get; set; } = null!;

    public string Result { get; set; } = null!;

    public string Recomendation { get; set; } = null!;

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual ICollection<Hospitalprescription> Hospitalprescriptions { get; set; } = new List<Hospitalprescription>();

    public virtual Medicalactivetype MedicalType { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;
}
