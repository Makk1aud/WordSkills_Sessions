using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class InsurancePole
{
    public int InsurancePolicyId { get; set; }

    public string PolicyNum { get; set; } = null!;

    public DateTime EndDate { get; set; }

    public virtual ICollection<MedicalCard> MedicalCards { get; set; } = new List<MedicalCard>();
}
