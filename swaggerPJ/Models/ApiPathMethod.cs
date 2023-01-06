using System;
using System.Collections.Generic;

namespace swaggerPJ.Models;

public partial class ApiPathMethod
{
    public int Id { get; set; }

    public string? Method { get; set; }

    public int? ApiPathsId { get; set; }

    public virtual ApiPath? ApiPaths { get; set; }

    public virtual ICollection<ApiRequestbody> ApiRequestbodies { get; } = new List<ApiRequestbody>();

    public virtual ICollection<ApiResponse> ApiResponses { get; } = new List<ApiResponse>();
}
