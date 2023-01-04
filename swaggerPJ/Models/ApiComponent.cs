using System;
using System.Collections.Generic;

namespace swaggerPJ.Models;

public partial class ApiComponent
{
    public int Id { get; set; }

    public int? ApiId { get; set; }

    public string Name { get; set; } = null!;

    public string? Type { get; set; }
}
