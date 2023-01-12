using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace swaggerPJ.Models;

public partial class SwaggerContext : DbContext
{
    public SwaggerContext()
    {
    }

    public SwaggerContext(DbContextOptions<SwaggerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ApiComponent> ApiComponents { get; set; }

    public virtual DbSet<ApiComponentProperty> ApiComponentProperties { get; set; }

    public virtual DbSet<ApiPath> ApiPaths { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolePermission> RolePermissions { get; set; }

    public virtual DbSet<RoleUser> RoleUsers { get; set; }

    public virtual DbSet<Tenant> Tenants { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=swagger;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApiComponent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ApiCompo__3214EC07BE4D109B");

            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Type).HasMaxLength(255);
        });

        modelBuilder.Entity<ApiComponentProperty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ApiCompo__3214EC07DD64438C");

            entity.ToTable("ApiComponentProperty");

            entity.Property(e => e.Format).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Type).HasMaxLength(255);
        });

        modelBuilder.Entity<ApiPath>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ApiPaths__3214EC0716BAF799");

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.ExternalPath).HasMaxLength(255);
            entity.Property(e => e.InternalPath).HasMaxLength(255);
            entity.Property(e => e.IsPublic)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Method).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.RequestBodyItems).HasMaxLength(255);
            entity.Property(e => e.ResponseItems).HasMaxLength(255);
            entity.Property(e => e.Tags).HasMaxLength(255);
            entity.Property(e => e.UserId).HasColumnName("User_id");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.ToTable("Permission", tb => tb.HasComment("權限資料表"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasComment("權限識別碼(使用snowflake產生)");
            entity.Property(e => e.Action)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("動作名稱");
            entity.Property(e => e.CreatedDate)
                .HasPrecision(4)
                .HasComment("資料建立時間");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasComment("權限描述");
            entity.Property(e => e.Domain)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("領域名稱");
            entity.Property(e => e.ExternalMethod)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasComment("HTTP 動作 (GET|POST|...)");
            entity.Property(e => e.ExternalPath)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("對外路徑");
            entity.Property(e => e.InternalDns)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("對內名稱")
                .HasColumnName("InternalDNS");
            entity.Property(e => e.InternalMethod)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasComment("HTTP 動作 (GET|POST|...)");
            entity.Property(e => e.InternalPath)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("對內路徑");
            entity.Property(e => e.InternalPort).HasComment("對內Port");
            entity.Property(e => e.IsPublic)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasComment("是否公開 (0:不公開 1:公開)");
            entity.Property(e => e.ModifiedDate)
                .HasPrecision(4)
                .HasComment("資料異動時間");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("權限名稱");
            entity.Property(e => e.Protocol)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasComment("通訊方式 0:Restful 1:gRPC 2:WebSocket");
            entity.Property(e => e.Resource)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("資源名稱");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role", tb => tb.HasComment("角色資料表"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasComment("角色識別碼(使用snowflake產生)");
            entity.Property(e => e.CreatedDate)
                .HasPrecision(4)
                .HasComment("資料建立時間");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasComment("Role描述");
            entity.Property(e => e.ModifiedDate)
                .HasPrecision(4)
                .HasComment("資料異動時間");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Role名稱");
            entity.Property(e => e.TenantId).HasComment("租戶識別碼");
            entity.Property(e => e.Type)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasComment("角色類型(保留)");
        });

        modelBuilder.Entity<RolePermission>(entity =>
        {
            entity.HasKey(e => new { e.RoleId, e.PermissionId });

            entity.ToTable("RolePermission", tb => tb.HasComment("角色權限對應表"));

            entity.Property(e => e.RoleId).HasComment("權限識別碼");
            entity.Property(e => e.PermissionId).HasComment("權限識別碼");
        });

        modelBuilder.Entity<RoleUser>(entity =>
        {
            entity.HasKey(e => new { e.RoleId, e.UserId });

            entity.ToTable("RoleUser", tb => tb.HasComment("角色使用者對應表"));

            entity.Property(e => e.RoleId).HasComment("角色識別碼");
            entity.Property(e => e.UserId).HasComment("使用者識別碼");
        });

        modelBuilder.Entity<Tenant>(entity =>
        {
            entity.ToTable("Tenant", tb => tb.HasComment("租戶資料表"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasComment("租戶識別碼(使用snowflake產生)");
            entity.Property(e => e.CreatedDate)
                .HasPrecision(4)
                .HasComment("資料建立時間");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasComment("租戶描述");
            entity.Property(e => e.ModifiedDate)
                .HasPrecision(4)
                .HasComment("資料異動時間");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("租戶名稱");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasComment("租戶狀態; 0：停用 1：啟用");
            entity.Property(e => e.Type)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasComment("租戶類型 (R:根租戶, G:一般租戶)");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User", tb => tb.HasComment("使用者資料表"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasComment("使用者識別碼(使用snowflake產生)");
            entity.Property(e => e.AccessFailedCount).HasComment("驗證登入錯誤的次數");
            entity.Property(e => e.Account)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("使用者登入帳號，必須唯一");
            entity.Property(e => e.CreatedDate)
                .HasPrecision(4)
                .HasComment("資料建立時間");
            entity.Property(e => e.DepName)
                .HasMaxLength(20)
                .HasComment("部門名稱");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("email帳號");
            entity.Property(e => e.EmailConfirmed).HasComment("電子郵件是否已確認");
            entity.Property(e => e.FavoriteLink)
                .HasMaxLength(1000)
                .HasDefaultValueSql("('')")
                .HasComment("我的最愛連結");
            entity.Property(e => e.LockoutEnabled).HasComment("使用者帳號是否已鎖定");
            entity.Property(e => e.LockoutEnd)
                .HasPrecision(4)
                .HasComment("使用者帳號鎖定到期時間 (UTC偏移)");
            entity.Property(e => e.LoginDate)
                .HasPrecision(4)
                .HasComment("上次成功登入時間");
            entity.Property(e => e.ModifiedDate)
                .HasPrecision(4)
                .HasComment("資料異動時間");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasComment("使用者登入密碼");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("手機號碼");
            entity.Property(e => e.PhoneNumberConfirmed).HasComment("手機號碼是否已確認");
            entity.Property(e => e.StaffCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("員工編號");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasComment("使用者帳號狀態; 0：停用 1：啟用");
            entity.Property(e => e.Tel)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("室內電話");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasComment("使用者名稱");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
