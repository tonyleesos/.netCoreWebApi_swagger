using System;
using System.Collections.Generic;

namespace swaggerPJ.Models;

public partial class ApiPath
{
    public int Id { get; set; }

    public int? ApiId { get; set; }

    public string? Path { get; set; }

    public string? Description { get; set; }

    public virtual Apis? Apis { get; set; }

    public virtual ICollection<ApiPathMethod> ApiPathMethods { get; } = new List<ApiPathMethod>();

    public virtual ICollection<ApiTag> ApiTags { get; } = new List<ApiTag>();
}
