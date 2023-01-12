using System;
using System.Collections.Generic;

namespace swaggerPJ.Models;

public partial class ApiComponentProperty
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Type { get; set; }

    public string? Format { get; set; }

    public bool? ReadOnly { get; set; }

    public bool? Nullable { get; set; }

    public int? ApiComponentsId { get; set; }
}
