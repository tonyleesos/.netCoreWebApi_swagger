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

    public virtual DbSet<ApiInfo> ApiInfos { get; set; }

    public virtual DbSet<ApiPath> ApiPaths { get; set; }

    public virtual DbSet<ApiRequestbody> ApiRequestbodies { get; set; }

    public virtual DbSet<ApiResponse> ApiResponses { get; set; }

    public virtual DbSet<ApiServer> ApiServers { get; set; }

    public virtual DbSet<ApiTag> ApiTags { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=swagger;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApiComponent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__api_comp__3213E83FAD86AF22");

            entity.ToTable("api_components");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
        });

        modelBuilder.Entity<ApiComponentProperty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__api_comp__3213E83F20CB9FC2");

            entity.ToTable("api_component_property");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApiComponentsId).HasColumnName("api_components_id");
            entity.Property(e => e.Format)
                .HasMaxLength(255)
                .HasColumnName("format");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Nullable).HasColumnName("nullable");
            entity.Property(e => e.ReadOnly).HasColumnName("readOnly");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");

            entity.HasOne(d => d.ApiComponents).WithMany(p => p.ApiComponentProperties)
                .HasForeignKey(d => d.ApiComponentsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_api_component_property_api_components");
        });

        modelBuilder.Entity<ApiInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__apis__3213E83F6F8A2545");

            entity.ToTable("api_info");

            entity.Property(e => e.Id).HasColumnName("id");
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

        modelBuilder.Entity<ApiPath>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__api_path__3213E83F994C512A");

            entity.ToTable("api_paths");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.ExternalPath)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.InternalPath)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.IsPublic)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Method)
                .HasMaxLength(255)
                .HasColumnName("method");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.RequestBodyItems)
                .HasMaxLength(255)
                .HasColumnName("requestBodyItems");
            entity.Property(e => e.ResponseItems)
                .HasMaxLength(255)
                .HasColumnName("responseItems");
            entity.Property(e => e.Tags)
                .HasMaxLength(255)
                .HasColumnName("tags");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<ApiRequestbody>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__content__3214EC0728C4CD7D");

            entity.ToTable("api_requestbody");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApiPathsId).HasColumnName("api_paths_id");
            entity.Property(e => e.Ref)
                .HasMaxLength(255)
                .HasColumnName("$ref");
            entity.Property(e => e.SchemaType)
                .HasMaxLength(255)
                .HasColumnName("schema_type");
            entity.Property(e => e.Tpye)
                .HasMaxLength(255)
                .HasColumnName("tpye");
        });

        modelBuilder.Entity<ApiResponse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__api_resp__3213E83F885401AB");

            entity.ToTable("api_responses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApiPathsId).HasColumnName("api_paths_id");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .HasColumnName("code");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Ref)
                .HasMaxLength(255)
                .HasColumnName("$ref");
            entity.Property(e => e.SchemaType)
                .HasMaxLength(255)
                .HasColumnName("schema_type");
            entity.Property(e => e.Tpye)
                .HasMaxLength(255)
                .HasColumnName("tpye");
        });

        modelBuilder.Entity<ApiServer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__api_serv__3213E83F7D41E25A");

            entity.ToTable("api_servers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApiId).HasColumnName("api_id");
            entity.Property(e => e.Descript)
                .HasMaxLength(255)
                .HasColumnName("descript");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasColumnName("url");

            entity.HasOne(d => d.Api).WithMany(p => p.ApiServers)
                .HasForeignKey(d => d.ApiId)
                .HasConstraintName("FK_api_servers_apis");
        });

        modelBuilder.Entity<ApiTag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__api_tags__3214EC073C006822");

            entity.ToTable("api_tags");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApiPathsId).HasColumnName("api_paths_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
