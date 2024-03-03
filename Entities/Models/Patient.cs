using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Patient
{
    public int PatientId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public string Passport { get; set; } = null!;

    public int GenderId { get; set; }

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? WorkPlace { get; set; }

    public string? PhotoPath { get; set; }

    public int? MedicalCardId { get; set; }

    public virtual Gender Gender { get; set; } = null!;

    public virtual ICollection<Hospitalisation> Hospitalisations { get; set; } = new List<Hospitalisation>();

    public virtual ICollection<Hospitalprescription> Hospitalprescriptions { get; set; } = new List<Hospitalprescription>();

    public virtual Medicalcard? MedicalCard { get; set; }

    public virtual ICollection<Medicalactivite> Medicalactivites { get; set; } = new List<Medicalactivite>();
}
