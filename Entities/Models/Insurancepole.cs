using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Insurancepole
{
    public int InsurancePolicyId { get; set; }

    public string PolicyNum { get; set; } = null!;

    public DateTime EndDate { get; set; }

    public virtual ICollection<Medicalcard> Medicalcards { get; set; } = new List<Medicalcard>();
}
