using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Doctor
{
    public int DoctorId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public string LoginCode { get; set; } = null!;

    public int PositionId { get; set; }

    public virtual ICollection<MedicalActivite> MedicalActivites { get; set; } = new List<MedicalActivite>();

    public virtual Position Position { get; set; } = null!;
}
