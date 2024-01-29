using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Medicalcard
{
    public int MedicalCardId { get; set; }

    public DateTime? IssueDate { get; set; }

    public DateTime LastContactDate { get; set; }

    public DateTime? NextContactDate { get; set; }

    public int InsurancePolicyId { get; set; }

    public virtual Insurancepole InsurancePolicy { get; set; } = null!;

    public virtual ICollection<Medicalhistory> Medicalhistories { get; set; } = new List<Medicalhistory>();

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
