using System;
using System.Collections.Generic;

namespace swaggerPJ.Models;

public partial class ApiTag
{
    public int Id { get; set; }

    public int? ApiPathsId { get; set; }

    public string? Name { get; set; }
}
