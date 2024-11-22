using System;
using Lab6.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ECommerce.Migrations
{
    [DbContext(typeof(ECommerceDbContext))]
    partial class ECommerceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0") // або ваша версія EF Core
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            // Таблиця Customers
            modelBuilder.Entity("YourNamespace.Models.Customer", b =>
            {
                b.Property<int>("CustomerId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<string>("AddressLine1")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("AddressLine2")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("AddressLine3")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("AddressLine4")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Country")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("EmailAddress")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("FirstName")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Gender")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("LastName")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("LoginName")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("LoginPassword")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("MiddleInitial")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("OtherDetails")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("PhoneNumber")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("StateCountyProvince")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("TownCity")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("CustomerId");

                b.ToTable("Customers");
            });

            // Таблиця Accounts
            modelBuilder.Entity("YourNamespace.Models.Account", b =>
            {
                b.Property<int>("AccountId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<string>("AccountName")
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("CustomerId")
                    .HasColumnType("int");

                b.Property<DateTime>("DateAccountOpened")
                    .HasColumnType("datetime2");

                b.Property<string>("OtherAccountDetails")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("AccountId");

                b.HasIndex("CustomerId");

                b.ToTable("Accounts");
            });

            // Таблиця Products
            modelBuilder.Entity("YourNamespace.Models.Product", b =>
            {
                b.Property<int>("ProductId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<string>("OtherProductDetails")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("ProductColor")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("ProductName")
                    .HasColumnType("nvarchar(max)");

                b.Property<decimal>("ProductPrice")
                    .HasColumnType("decimal(18,2)");

                b.Property<string>("ProductSize")
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("ProductionTypeCode")
                    .HasColumnType("int");

                b.HasKey("ProductId");

                b.HasIndex("ProductionTypeCode");

                b.ToTable("Products");
            });

            // Таблиця ProductTypes
            modelBuilder.Entity("YourNamespace.Models.ProductType", b =>
            {
                b.Property<int>("ProductTypeCode")
                    .HasColumnType("int");

                b.Property<int?>("ParentProductTypeCode")
                    .HasColumnType("int");

                b.Property<string>("ProductTypeDescription")
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("VatRating")
                    .HasColumnType("int");

                b.HasKey("ProductTypeCode");

                b.ToTable("ProductTypes");
            });

            // Таблиця Orders
            modelBuilder.Entity("YourNamespace.Models.Order", b =>
            {
                b.Property<int>("OrderId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<int>("CustomerId")
                    .HasColumnType("int");

                b.Property<DateTime>("DateOrderPlaced")
                    .HasColumnType("datetime2");

                b.Property<string>("OrderDetails")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("OrderId");

                b.HasIndex("CustomerId");

                b.ToTable("Orders");
            });

            // Таблиця OrderItems
            modelBuilder.Entity("YourNamespace.Models.OrderItem", b =>
            {
                b.Property<int>("OrderItemId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<string>("OtherOrderItemDetails")
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("OrderId")
                    .HasColumnType("int");

                b.Property<int>("ProductId")
                    .HasColumnType("int");

                b.Property<int>("ProductQuantity")
                    .HasColumnType("int");

                b.HasKey("OrderItemId");

                b.HasIndex("OrderId");

                b.HasIndex("ProductId");

                b.ToTable("OrderItems");
            });

            // Встановлення зв'язків між таблицями
            modelBuilder.Entity("YourNamespace.Models.Account", b =>
            {
                b.HasOne("YourNamespace.Models.Customer", "Customer")
                    .WithMany("Accounts")
                    .HasForeignKey("CustomerId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("YourNamespace.Models.Product", b =>
            {
                b.HasOne("YourNamespace.Models.ProductType", "ProductType")
                    .WithMany("Products")
                    .HasForeignKey("ProductionTypeCode")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("YourNamespace.Models.Order", b =>
            {
                b.HasOne("YourNamespace.Models.Customer", "Customer")
                    .WithMany("Orders")
                    .HasForeignKey("CustomerId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("YourNamespace.Models.OrderItem", b =>
            {
                b.HasOne("YourNamespace.Models.Order", "Order")
                    .WithMany("OrderItems")
                    .HasForeignKey("OrderId")
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne("YourNamespace.Models.Product", "Product")
                    .WithMany("OrderItems")
                    .HasForeignKey("ProductId")
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
