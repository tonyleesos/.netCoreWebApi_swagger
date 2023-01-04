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

    public virtual DbSet<Api> Apis { get; set; }

    public virtual DbSet<ApiComponent> ApiComponents { get; set; }

    public virtual DbSet<ApiOperation> ApiOperations { get; set; }

    public virtual DbSet<ApiParameter> ApiParameters { get; set; }

    public virtual DbSet<ApiPath> ApiPaths { get; set; }

    public virtual DbSet<ApiRefferenceProperty> ApiRefferenceProperties { get; set; }

    public virtual DbSet<ApiResponse> ApiResponses { get; set; }

    public virtual DbSet<ApiServer> ApiServers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=swagger;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Api>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__apis__3213E83F341F9C6A");

            entity.ToTable("apis");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.Version)
                .HasMaxLength(255)
                .HasColumnName("version");
        });

        modelBuilder.Entity<ApiComponent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__api_comp__3213E83FF37CF7F8");

            entity.ToTable("api_components");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ApiId).HasColumnName("api_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
        });

        modelBuilder.Entity<ApiOperation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__api_oper__3213E83FB6B3A9BF");

            entity.ToTable("api_operations");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ApiPathId).HasColumnName("api_path_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.OperationId).HasColumnName("operationId");
        });

        modelBuilder.Entity<ApiParameter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__api_para__3213E83F2584CB92");

            entity.ToTable("api_parameters");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ApiOperationId).HasColumnName("api_operation_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.In)
                .HasMaxLength(255)
                .HasColumnName("in");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ApiPath>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__api_path__3213E83FCCD3FEF5");

            entity.ToTable("api_paths");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ApiId).HasColumnName("api_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Path)
                .HasMaxLength(255)
                .HasColumnName("path");
        });

        modelBuilder.Entity<ApiRefferenceProperty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__api_reff__3213E83F8B5A0009");

            entity.ToTable("api_refference_properties");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ApiReferrenceId).HasColumnName("api_referrence_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
        });

        modelBuilder.Entity<ApiResponse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__api_resp__3213E83F9A1B1725");

            entity.ToTable("api_responses");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ApiPathId).HasColumnName("api_path_id");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .HasColumnName("code");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.SchemaType)
                .HasMaxLength(255)
                .HasColumnName("schema_type");
        });

        modelBuilder.Entity<ApiServer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__api_serv__3213E83F2FC00A4B");

            entity.ToTable("api_servers");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasColumnName("url");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
