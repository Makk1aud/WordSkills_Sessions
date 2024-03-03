using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Hospitalisation
{
    public int HospitalisationId { get; set; }

    public int PatientId { get; set; }

    public int HospitalId { get; set; }

    public int AdmissionTypeId { get; set; }

    public string HospitalisationCode { get; set; } = null!;

    public DateTime HospitalisationDate { get; set; }

    public string Purpose { get; set; } = null!;

    public string? Diagnose { get; set; }

    public virtual Admissiontype AdmissionType { get; set; } = null!;

    public virtual Hospital Hospital { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;
}
