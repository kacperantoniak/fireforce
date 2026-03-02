using System;
using System.Collections.Generic;

namespace Fireforce.Models;

public partial class Car
{
    public int Id { get; set; }

    public int? DeptId { get; set; }

    public string Vin { get; set; } = null!;

    public string Plate { get; set; } = null!;

    public string Brand { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string? Notes { get; set; }

    public virtual Dept? Dept { get; set; }
}
