using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fireforce.Models;

public partial class Dept
{
    public int Id { get; }

    [Required]
    [MaxLength(16)]
    [RegularExpression(@"^[a-zA-Z0-9\s\-]+$", ErrorMessage = "Invalid format")]
    public string Voivodeship { get; set; } = null!;

    [Required]
    [RegularExpression(@"^\d{5}$", ErrorMessage ="Invalid format")]
    public string PostalCode { get; set; } = null!;

    [RegularExpression(@"^[a-zA-Z0-9\s\-]+$", ErrorMessage = "Invalid format")]
    public string? Street { get; set; }

    [Required]
    public int Bnumber { get; set; }

    public int? Aptnumber { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    public virtual ICollection<Emp> Emps { get; set; } = new List<Emp>();

    public virtual ICollection<Extinguisher> Extinguishers { get; set; } = new List<Extinguisher>();
}
