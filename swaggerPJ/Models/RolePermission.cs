using System;
using System.Collections.Generic;

namespace swaggerPJ.Models;

/// <summary>
/// 角色權限對應表
/// </summary>
public partial class RolePermission
{
    /// <summary>
    /// 權限識別碼
    /// </summary>
    public long RoleId { get; set; }

    /// <summary>
    /// 權限識別碼
    /// </summary>
    public long PermissionId { get; set; }
}
