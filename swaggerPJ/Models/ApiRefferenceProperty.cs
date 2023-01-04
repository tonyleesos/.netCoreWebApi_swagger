using System;
using System.Collections.Generic;

namespace swaggerPJ.Models;

public partial class ApiRefferenceProperty
{
    public int Id { get; set; }

    public int? ApiReferrenceId { get; set; }

    public string Name { get; set; } = null!;

    public string? Type { get; set; }
}
