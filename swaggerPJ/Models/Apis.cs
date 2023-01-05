using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace swaggerPJ.Models;

public partial class Apis
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string Version { get; set; } = null!;

}
