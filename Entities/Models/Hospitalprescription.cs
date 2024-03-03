using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Hospitalprescription
{
    public int HospitalPrescriptionId { get; set; }

    public int PatientId { get; set; }

    public int MedicalActivitesId { get; set; }

    public string DrugTitle { get; set; } = null!;

    public virtual Medicalactivite MedicalActivites { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;
}
