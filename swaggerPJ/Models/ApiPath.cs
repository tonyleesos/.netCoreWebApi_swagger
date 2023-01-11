using System;
using System.Collections.Generic;

namespace swaggerPJ.Models;

public partial class ApiPath
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Method { get; set; }

    public string? RequestBodyItems { get; set; }

    public string? Tags { get; set; }

    public string? ResponseItems { get; set; }

    public string? InternalPath { get; set; }

    public int? InternalPort { get; set; }

    public string? ExternalPath { get; set; }

    public string? IsPublic { get; set; }

    public int? UserId { get; set; }
}
