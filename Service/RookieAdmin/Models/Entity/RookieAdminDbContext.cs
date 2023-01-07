using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RookieAdmin.Models.Entity
{
    public partial class RookieAdminDbContext : DbContext
    {
        public RookieAdminDbContext()
        {
        }

        public RookieAdminDbContext(DbContextOptions<RookieAdminDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SysMenu> SysMenus { get; set; } = null!;
        public virtual DbSet<SysPermission> SysPermissions { get; set; } = null!;
        public virtual DbSet<SysRole> SysRoles { get; set; } = null!;
        public virtual DbSet<SysUser> SysUsers { get; set; } = null!;
        public virtual DbSet<SysUserRole> SysUserRoles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=Rookiedb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SysMenu>(entity =>
            {
                entity.ToTable("SysMenu");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasComment("Id");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Icon)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("ICON圖示");

                entity.Property(e => e.IsEnable).HasComment("是否顯示(0 不顯示, 1 顯示)");

                entity.Property(e => e.MenuName)
                    .HasMaxLength(50)
                    .HasComment("選單名稱");

                entity.Property(e => e.MenuType).HasComment("類型 ( 1 目錄, 2 選單, 3 功能)");

                entity.Property(e => e.ParentId).HasComment("父節點Id");

                entity.Property(e => e.PermsCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("權限標記");

                entity.Property(e => e.ReMark)
                    .HasMaxLength(200)
                    .HasComment("備註");

                entity.Property(e => e.Sort).HasComment("排序");

                entity.Property(e => e.Target).HasComment("打開方式(1 頁籤, 2 另開新視窗)");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.Url)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasComment("網址");
            });

            modelBuilder.Entity<SysPermission>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.MenuId });

                entity.ToTable("SysPermission");
            });

            modelBuilder.Entity<SysRole>(entity =>
            {
                entity.ToTable("SysRole");

                entity.Property(e => e.Id).HasComment("Id");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Remark)
                    .HasMaxLength(200)
                    .HasComment("備註");

                entity.Property(e => e.RoleCode)
                    .HasMaxLength(50)
                    .HasComment("權限標記");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .HasComment("權限名稱");

                entity.Property(e => e.Sort).HasComment("排序");

                entity.Property(e => e.Status).HasComment("狀態(0 不啟用, 1 啟用)");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<SysUser>(entity =>
            {
                entity.ToTable("SysUser");

                entity.Property(e => e.Id).HasComment("Id");

                entity.Property(e => e.Account)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasComment("帳號");

                entity.Property(e => e.Avatar)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasComment("頭像路徑");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DeptId).HasComment("部門ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasComment("電子郵件");

                entity.Property(e => e.Enable).HasComment("是否啟用(0 否 1 是)");

                entity.Property(e => e.ErrorCount).HasComment("登入錯誤次數");

                entity.Property(e => e.LoginTime)
                    .HasColumnType("datetime")
                    .HasComment("上次登入時間");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasComment("姓名");

                entity.Property(e => e.Password)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasComment("密碼");

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("電話");

                entity.Property(e => e.PwdUpdateTime)
                    .HasColumnType("datetime")
                    .HasComment("最後密碼更新時間");

                entity.Property(e => e.Salt)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasComment("加鹽");

                entity.Property(e => e.Status).HasComment("是否刪除(0 已刪除 1 使用中)");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<SysUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.ToTable("SysUserRole");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
