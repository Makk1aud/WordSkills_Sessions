using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class MedicalActivite
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

    public virtual ICollection<HospitalPrescription> HospitalPrescriptions { get; set; } = new List<HospitalPrescription>();

    public virtual MedicalActiveType MedicalType { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;
}
