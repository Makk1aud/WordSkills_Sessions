using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Gender
{
    public int GenderId { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
