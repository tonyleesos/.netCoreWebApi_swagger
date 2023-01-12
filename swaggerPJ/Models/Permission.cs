using System;
using System.Collections.Generic;

namespace swaggerPJ.Models;

/// <summary>
/// 權限資料表
/// </summary>
public partial class Permission
{
    /// <summary>
    /// 權限識別碼(使用snowflake產生)
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 權限名稱
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// 權限描述
    /// </summary>
    public string Description { get; set; } = null!;

    /// <summary>
    /// 對內名稱
    /// </summary>
    public string InternalDns { get; set; } = null!;

    /// <summary>
    /// HTTP 動作 (GET|POST|...)
    /// </summary>
    public string InternalMethod { get; set; } = null!;

    /// <summary>
    /// 對內路徑
    /// </summary>
    public string InternalPath { get; set; } = null!;

    /// <summary>
    /// 對內Port
    /// </summary>
    public int InternalPort { get; set; }

    /// <summary>
    /// HTTP 動作 (GET|POST|...)
    /// </summary>
    public string ExternalMethod { get; set; } = null!;

    /// <summary>
    /// 對外路徑
    /// </summary>
    public string ExternalPath { get; set; } = null!;

    /// <summary>
    /// 通訊方式 0:Restful 1:gRPC 2:WebSocket
    /// </summary>
    public string Protocol { get; set; } = null!;

    /// <summary>
    /// 是否公開 (0:不公開 1:公開)
    /// </summary>
    public string IsPublic { get; set; } = null!;

    /// <summary>
    /// 領域名稱
    /// </summary>
    public string Domain { get; set; } = null!;

    /// <summary>
    /// 資源名稱
    /// </summary>
    public string Resource { get; set; } = null!;

    /// <summary>
    /// 動作名稱
    /// </summary>
    public string Action { get; set; } = null!;

    /// <summary>
    /// 資料建立時間
    /// </summary>
    public DateTimeOffset CreatedDate { get; set; }

    /// <summary>
    /// 資料異動時間
    /// </summary>
    public DateTimeOffset ModifiedDate { get; set; }
}
