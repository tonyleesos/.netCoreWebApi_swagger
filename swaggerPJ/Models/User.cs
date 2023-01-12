using System;
using System.Collections.Generic;

namespace swaggerPJ.Models;

/// <summary>
/// 使用者資料表
/// </summary>
public partial class User
{
    /// <summary>
    /// 使用者識別碼(使用snowflake產生)
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 使用者名稱
    /// </summary>
    public string UserName { get; set; } = null!;

    /// <summary>
    /// 使用者登入帳號，必須唯一
    /// </summary>
    public string Account { get; set; } = null!;

    /// <summary>
    /// 使用者登入密碼
    /// </summary>
    public string PasswordHash { get; set; } = null!;

    /// <summary>
    /// 室內電話
    /// </summary>
    public string Tel { get; set; } = null!;

    /// <summary>
    /// 手機號碼
    /// </summary>
    public string PhoneNumber { get; set; } = null!;

    /// <summary>
    /// email帳號
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// 員工編號
    /// </summary>
    public string StaffCode { get; set; } = null!;

    /// <summary>
    /// 部門名稱
    /// </summary>
    public string DepName { get; set; } = null!;

    /// <summary>
    /// 我的最愛連結
    /// </summary>
    public string FavoriteLink { get; set; } = null!;

    /// <summary>
    /// 驗證登入錯誤的次數
    /// </summary>
    public int AccessFailedCount { get; set; }

    /// <summary>
    /// 使用者帳號狀態; 0：停用 1：啟用
    /// </summary>
    public string Status { get; set; } = null!;

    /// <summary>
    /// 電子郵件是否已確認
    /// </summary>
    public bool EmailConfirmed { get; set; }

    /// <summary>
    /// 手機號碼是否已確認
    /// </summary>
    public bool PhoneNumberConfirmed { get; set; }

    /// <summary>
    /// 使用者帳號是否已鎖定
    /// </summary>
    public bool LockoutEnabled { get; set; }

    /// <summary>
    /// 使用者帳號鎖定到期時間 (UTC偏移)
    /// </summary>
    public DateTimeOffset? LockoutEnd { get; set; }

    /// <summary>
    /// 上次成功登入時間
    /// </summary>
    public DateTimeOffset? LoginDate { get; set; }

    /// <summary>
    /// 資料建立時間
    /// </summary>
    public DateTimeOffset CreatedDate { get; set; }

    /// <summary>
    /// 資料異動時間
    /// </summary>
    public DateTimeOffset ModifiedDate { get; set; }
}
