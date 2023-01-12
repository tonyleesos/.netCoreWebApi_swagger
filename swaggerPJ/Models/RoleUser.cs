using System;
using System.Collections.Generic;

namespace swaggerPJ.Models;

/// <summary>
/// 角色使用者對應表
/// </summary>
public partial class RoleUser
{
    /// <summary>
    /// 角色識別碼
    /// </summary>
    public long RoleId { get; set; }

    /// <summary>
    /// 使用者識別碼
    /// </summary>
    public long UserId { get; set; }
}
