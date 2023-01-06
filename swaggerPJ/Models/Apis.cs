using System;
using System.Collections.Generic;

namespace swaggerPJ.Models;

public partial class Apis
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string Version { get; set; } = null!;

    public virtual ICollection<ApiComponent>? ApiComponents { get; set; } = new List<ApiComponent>();

    public virtual ICollection<ApiPath>? ApiPaths { get; set; } = new List<ApiPath>();

    public virtual ICollection<ApiServer>? ApiServers { get; set; } = new List<ApiServer>();
}
