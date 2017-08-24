using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DATA;

namespace DATA.Migrations
{
    [DbContext(typeof(ShopOnlineDbContext))]
    partial class ShopOnlineDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DOMAIN.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("ProductId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("DOMAIN.Coupon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateInput");

                    b.Property<bool>("Status");

                    b.Property<int>("SupplierId");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.ToTable("Coupons");
                });

            modelBuilder.Entity("DOMAIN.CouponDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CouponId");

                    b.Property<decimal>("Price");

                    b.Property<int>("ProductID");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("CouponId");

                    b.HasIndex("ProductID");

                    b.ToTable("CouponDetails");
                });

            modelBuilder.Entity("DOMAIN.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<bool>("Status");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("DOMAIN.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("CustomerAddress")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("CustomerMessage")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("CustomerMobile")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("PaymentMethod")
                        .HasMaxLength(256);

                    b.Property<string>("PaymentStatus");

                    b.Property<bool>("Status");

                    b.HasKey("ID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DOMAIN.OrderDetail", b =>
                {
                    b.Property<int>("OrderId");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantitty");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("DOMAIN.Producer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Fax");

                    b.Property<string>("Infomation");

                    b.Property<string>("Logo");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<bool>("Status");

                    b.HasKey("Id");

                    b.ToTable("Producers");
                });

            modelBuilder.Entity("DOMAIN.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alias");

                    b.Property<int>("CategoryID");

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description");

                    b.Property<bool?>("HotFlag");

                    b.Property<string>("MoreImages")
                        .HasColumnType("xml");

                    b.Property<string>("Name");

                    b.Property<decimal?>("OriginalPrice");

                    b.Property<decimal>("Price");

                    b.Property<int>("ProducerId");

                    b.Property<decimal?>("PromotionPrice");

                    b.Property<bool>("Status");

                    b.Property<int>("SupplierId");

                    b.Property<int?>("Warranty");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("ProducerId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DOMAIN.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<int?>("DisplayOrder");

                    b.Property<bool?>("HomeFlag");

                    b.Property<string>("Image")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<int?>("ParentID");

                    b.HasKey("Id");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("DOMAIN.ProductTag", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<string>("TagId");

                    b.HasKey("ProductId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("ProductTags");
                });

            modelBuilder.Entity("DOMAIN.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Name");

                    b.Property<bool>("Status");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("DOMAIN.Tag", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("DOMAIN.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("PassWord");

                    b.Property<string>("Phone");

                    b.Property<string>("Question");

                    b.Property<string>("Reply");

                    b.Property<bool>("Status");

                    b.Property<int>("UserGroupId");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("UserGroupId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DOMAIN.UserGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("Promotion");

                    b.HasKey("Id");

                    b.ToTable("UserGroups");
                });

            modelBuilder.Entity("DOMAIN.Comment", b =>
                {
                    b.HasOne("DOMAIN.Product", "Product")
                        .WithMany("Comments")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DOMAIN.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DOMAIN.Coupon", b =>
                {
                    b.HasOne("DOMAIN.Supplier", "Supplier")
                        .WithMany("Coupons")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DOMAIN.CouponDetail", b =>
                {
                    b.HasOne("DOMAIN.Coupon", "Coupon")
                        .WithMany("CouponDetails")
                        .HasForeignKey("CouponId");

                    b.HasOne("DOMAIN.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DOMAIN.Customer", b =>
                {
                    b.HasOne("DOMAIN.User", "User")
                        .WithMany("Customers")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("DOMAIN.OrderDetail", b =>
                {
                    b.HasOne("DOMAIN.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DOMAIN.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DOMAIN.Product", b =>
                {
                    b.HasOne("DOMAIN.ProductCategory", "ProductCategory")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DOMAIN.Producer", "Producer")
                        .WithMany("Products")
                        .HasForeignKey("ProducerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DOMAIN.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DOMAIN.ProductTag", b =>
                {
                    b.HasOne("DOMAIN.Product", "Product")
                        .WithMany("ProductTags")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DOMAIN.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DOMAIN.User", b =>
                {
                    b.HasOne("DOMAIN.UserGroup", "UserGroup")
                        .WithMany("Users")
                        .HasForeignKey("UserGroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
