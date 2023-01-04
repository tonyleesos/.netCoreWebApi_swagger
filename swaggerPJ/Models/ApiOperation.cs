using System;
using System.Collections.Generic;

namespace swaggerPJ.Models;

public partial class ApiOperation
{
    public int Id { get; set; }

    public int? ApiPathId { get; set; }

    public string? Description { get; set; }

    public Guid? OperationId { get; set; }
}
