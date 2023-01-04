using System;
using System.Collections.Generic;

namespace swaggerPJ.Models;

public partial class ApiParameter
{
    public int Id { get; set; }

    public int? ApiOperationId { get; set; }

    public string Name { get; set; } = null!;

    public string In { get; set; } = null!;

    public string Description { get; set; } = null!;
}
