using System;
using System.Collections.Generic;

namespace swaggerPJ.Models;

public partial class ApiRequestbody
{
    public int Id { get; set; }

    public int? ApiPathsId { get; set; }

    public string? SchemaType { get; set; }

    public string? Ref { get; set; }

    public string? Tpye { get; set; }

    public virtual ApiPath? ApiPaths { get; set; }
}
