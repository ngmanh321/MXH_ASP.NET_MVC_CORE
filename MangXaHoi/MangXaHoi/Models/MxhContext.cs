using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MangXaHoi.Models;

public partial class MxhContext : DbContext
{
    public MxhContext()
    {
    }

    public MxhContext(DbContextOptions<MxhContext> options)
        : base(options)
    {
    }

	public virtual DbSet<Chat> Chats { get; set; }

	public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Like> Likes { get; set; }

    public virtual DbSet<Friend> Friends { get; set; }

    public virtual DbSet<Nguoidung> Nguoidungs { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=THUNGUYEN\\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
		modelBuilder.Entity<Chat>(entity =>
		{
			entity.HasKey(e => e.Idchat);

			entity.ToTable("Chat", tb => tb.HasTrigger("increase_ViTri"));


			entity.Property(e => e.Idchat).HasColumnName("IDChat");
			entity.Property(e => e.AvatarGui).HasMaxLength(50);
			entity.Property(e => e.AvatarNhan).HasMaxLength(50);
			entity.Property(e => e.NgayTao).HasColumnType("datetime");
			entity.Property(e => e.NoiDung).HasMaxLength(500);
			entity.Property(e => e.Tkgui)
				.HasMaxLength(50)
				.HasColumnName("TKGui");
			entity.Property(e => e.Tknhan)
				.HasMaxLength(50)
				.HasColumnName("TKNhan");
		});


		modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Idcomment);

            entity.ToTable("Comment", tb => tb.HasTrigger("Update_ngay"));

            entity.Property(e => e.Idcomment).HasColumnName("IDComment");
            entity.Property(e => e.Avatar).HasMaxLength(50);
            entity.Property(e => e.Idpost).HasColumnName("IDPost");
            entity.Property(e => e.NgayTao).HasColumnType("datetime");
            entity.Property(e => e.NoiDung).HasMaxLength(50);
            entity.Property(e => e.TaiKhoan).HasMaxLength(50);
        });

        modelBuilder.Entity<Like>(entity =>
        {
            entity.HasKey(e => new { e.Idpost, e.TaiKhoan });

            entity.ToTable("Like", tb => tb.HasTrigger("UpdateLike_ngay"));

            entity.Property(e => e.Idpost).HasColumnName("IDPost");
            entity.Property(e => e.TaiKhoan).HasMaxLength(50);
            entity.Property(e => e.Avatar).HasMaxLength(50);
            entity.Property(e => e.NgayTao).HasMaxLength(50);

        });

        modelBuilder.Entity<Friend>(entity =>
        {
            entity.HasKey(e => new { e.Tkgui, e.Tknhan });

            entity.ToTable("Friend");

            entity.Property(e => e.Tkgui)
                .HasMaxLength(50)
                .HasColumnName("TKGui");
            entity.Property(e => e.Tknhan)
                .HasMaxLength(50)
                .HasColumnName("TKNhan");
            entity.Property(e => e.AvatarGui).HasMaxLength(50);
            entity.Property(e => e.AvatarNhan).HasMaxLength(50);
        });


        modelBuilder.Entity<Nguoidung>(entity =>
        {
            entity.HasKey(e => e.TaiKhoan);

            entity.ToTable("Nguoidung", tb => tb.HasTrigger("UpdateUser_ngay"));

            entity.Property(e => e.TaiKhoan).HasMaxLength(50);
            entity.Property(e => e.AnhBia).HasMaxLength(50);
            entity.Property(e => e.Avatar).HasMaxLength(50);
            entity.Property(e => e.GioiThieu).HasMaxLength(50);
            entity.Property(e => e.GioiTinh).HasMaxLength(50);
            entity.Property(e => e.MatKhau).HasMaxLength(50);
            entity.Property(e => e.NgaySinh).HasMaxLength(50);
            entity.Property(e => e.NgayTao).HasColumnType("datetime");
            entity.Property(e => e.Sdt)
                .HasMaxLength(50)
                .HasColumnName("SDT");
            entity.Property(e => e.Ten).HasMaxLength(50);
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Idpost);

            entity.ToTable("Post", tb => tb.HasTrigger("UpdatePost_ngay"));

            entity.Property(e => e.Idpost).HasColumnName("IDPost");
            entity.Property(e => e.Anh).HasMaxLength(50);
            entity.Property(e => e.Avatar).HasMaxLength(50);
            entity.Property(e => e.NgayTao).HasColumnType("datetime");
            entity.Property(e => e.NoiDung).HasMaxLength(50);
            entity.Property(e => e.TaiKhoan).HasMaxLength(50);
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.TaiKhoanNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.TaiKhoan)
                .HasConstraintName("FK_Post_Nguoidung");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
