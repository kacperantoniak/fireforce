using System;
using System.Collections.Generic;

namespace Fireforce.Models;

public partial class Extinguisher
{
    public int Id { get; set; }

    public int? DeptId { get; set; }

    public long Serial { get; set; }

    public string Type { get; set; } = null!;

    public string? Note { get; set; }

    public virtual Dept? Dept { get; set; }
}
