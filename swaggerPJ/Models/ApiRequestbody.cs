using System;
using System.Collections.Generic;

namespace swaggerPJ.Models;

public partial class ApiRequestbody
{
    public int Id { get; set; }

    public int? ApiMethodId { get; set; }

    public string? SchemaType { get; set; }

    public string? Ref { get; set; }

    public virtual ApiPathMethod? ApiMethod { get; set; }
}
