using System;
using System.Collections.Generic;

namespace swaggerPJ.Models;

/// <summary>
/// 租戶資料表
/// </summary>
public partial class Tenant
{
    /// <summary>
    /// 租戶識別碼(使用snowflake產生)
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 租戶名稱
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// 租戶描述
    /// </summary>
    public string Description { get; set; } = null!;

    /// <summary>
    /// 租戶類型 (R:根租戶, G:一般租戶)
    /// </summary>
    public string Type { get; set; } = null!;

    /// <summary>
    /// 租戶狀態; 0：停用 1：啟用
    /// </summary>
    public string Status { get; set; } = null!;

    /// <summary>
    /// 資料建立時間
    /// </summary>
    public DateTimeOffset CreatedDate { get; set; }

    /// <summary>
    /// 資料異動時間
    /// </summary>
    public DateTimeOffset ModifiedDate { get; set; }
}
