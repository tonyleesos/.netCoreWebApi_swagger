using System;
using System.Collections.Generic;

namespace swaggerPJ.Models;

/// <summary>
/// 角色資料表
/// </summary>
public partial class Role
{
    /// <summary>
    /// 角色識別碼(使用snowflake產生)
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 租戶識別碼
    /// </summary>
    public long TenantId { get; set; }

    /// <summary>
    /// Role名稱
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Role描述
    /// </summary>
    public string Description { get; set; } = null!;

    /// <summary>
    /// 角色類型(保留)
    /// </summary>
    public string Type { get; set; } = null!;

    /// <summary>
    /// 資料建立時間
    /// </summary>
    public DateTimeOffset CreatedDate { get; set; }

    /// <summary>
    /// 資料異動時間
    /// </summary>
    public DateTimeOffset ModifiedDate { get; set; }
}
