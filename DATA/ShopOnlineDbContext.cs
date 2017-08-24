﻿using DOMAIN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DATA
{
    public class ShopOnlineDbContext:DbContext
    {
        public ShopOnlineDbContext(DbContextOptions<ShopOnlineDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            //builder.Entity<OrderDetail>()
            //.ToTable("OrderDetails");
            builder.Entity<OrderDetail>()
            .HasKey(a => new { a.OrderId, a.ProductId });
            builder.Entity<ProductTag>()
            .HasKey(a => new { a.ProductId, a.TagId });
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Coupon> Coupons { get; set; }
        public virtual DbSet<CouponDetail> CouponDetails { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategorys { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }
        public virtual DbSet<ProductTag> ProductTags { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

    }
}
