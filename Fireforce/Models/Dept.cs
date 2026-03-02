using System;
using System.Collections.Generic;

namespace Fireforce.Models;

public partial class Dept
{
    public int Id { get; set; }

    public string Voivodeship { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string? Street { get; set; }

    public int Bnumber { get; set; }

    public int? Aptnumber { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    public virtual ICollection<Emp> Emps { get; set; } = new List<Emp>();

    public virtual ICollection<Extinguisher> Extinguishers { get; set; } = new List<Extinguisher>();
}
