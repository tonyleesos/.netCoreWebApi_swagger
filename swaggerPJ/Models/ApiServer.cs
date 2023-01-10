using System;
using System.Collections.Generic;

namespace swaggerPJ.Models;

public partial class ApiServer
{
    public int Id { get; set; }

    public int? ApiId { get; set; }

    public string? Url { get; set; }

    public string? Descript { get; set; }

    public virtual ApiInfo? Api { get; set; }

}
