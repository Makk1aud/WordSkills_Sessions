using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class HospitalPrescription
{
    public int HospitalPrescriptionId { get; set; }

    public int PatientId { get; set; }

    public int MedicalActivitesId { get; set; }

    public string DrugTitle { get; set; } = null!;

    public virtual MedicalActivite MedicalActivites { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;
}
