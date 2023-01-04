using System;
using System.Collections.Generic;

namespace swaggerPJ.Models;

public partial class ApiResponse
{
    public int Id { get; set; }

    public int? ApiPathId { get; set; }

    public string? Code { get; set; }

    public string Description { get; set; } = null!;

    public string? SchemaType { get; set; }
}
