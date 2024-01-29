using Entities.Models;
using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Position
{
    public int PositionId { get; set; }

    public string PositionTitle { get; set; } = null!;

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}
