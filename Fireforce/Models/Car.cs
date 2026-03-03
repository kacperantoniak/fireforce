using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fireforce.Models;

public partial class Car
{
    public int Id { get; }

    public int? DeptId { get; set; }

    [Required]
    public string Vin { get; set; } = null!;

    [Required]
    public string Plate { get; set; } = null!;

    public string Brand { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string? Notes { get; set; }

    public virtual Dept? Dept { get; set; }
}
