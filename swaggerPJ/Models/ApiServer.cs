using System;
using System.Collections.Generic;

namespace swaggerPJ.Models;

public partial class ApiServer
{
    public int Id { get; set; }

    public int? ProjectId { get; set; }

    public string? Url { get; set; }
}
