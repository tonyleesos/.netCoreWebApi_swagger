using System;
using System.Collections.Generic;

namespace swaggerPJ.Models;

public partial class ApiPath
{
    public int Id { get; set; }

    public int? ApiId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Method { get; set; }

    public virtual ApiInfo? Api { get; set; }

    public virtual ICollection<ApiRequestbody> ApiRequestbodies { get; } = new List<ApiRequestbody>();

    public virtual ICollection<ApiResponse> ApiResponses { get; } = new List<ApiResponse>();

    public virtual ICollection<ApiTag> ApiTags { get; } = new List<ApiTag>();
}
