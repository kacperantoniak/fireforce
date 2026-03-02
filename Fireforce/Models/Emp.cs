using System;
using System.Collections.Generic;

namespace Fireforce.Models;

public partial class Emp
{
    public int Id { get; set; }

    public int? DeptId { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public decimal? Salary { get; set; }

    public virtual Dept? Dept { get; set; }
}
