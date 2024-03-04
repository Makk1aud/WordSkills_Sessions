using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class MedicalCard
{
    public int MedicalCardId { get; set; }

    public DateTime? IssueDate { get; set; }

    public DateTime LastContactDate { get; set; }

    public DateTime? NextContactDate { get; set; }

    public int InsurancePolicyId { get; set; }

    public virtual InsurancePole InsurancePolicy { get; set; } = null!;

    public virtual ICollection<MedicalHistory> MedicalHistories { get; set; } = new List<MedicalHistory>();

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
