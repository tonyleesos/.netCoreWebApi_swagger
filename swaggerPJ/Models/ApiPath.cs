using System;
using System.Collections.Generic;

namespace swaggerPJ.Models;

public partial class ApiPath
{
    public int Id { get; set; }

    public int? ApiId { get; set; }

    public string? Path { get; set; }

    public string? Description { get; set; }
}
