using Lab6.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using System;
using Microsoft.EntityFrameworkCore;
namespace Lab6.Data
{
    public class ECommerceDbContext : DbContext
    {
        // Конструктор DbContext
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options) { }

        // Відображення таблиць на моделі
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLineItem> InvoiceLineItems { get; set; }
        public DbSet<FinancialTransaction> FinancialTransactions { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }

        // Налаштування моделей у методі OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Customer
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerId);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.MiddleInitial).HasMaxLength(1);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.EmailAddress).IsRequired().HasMaxLength(100);
                entity.Property(e => e.LoginName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LoginPassword).IsRequired().HasMaxLength(100);
                entity.Property(e => e.OtherDetails).HasMaxLength(500);
            });

            // Account
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.AccountId);
                entity.Property(e => e.AccountName).IsRequired().HasMaxLength(50);
                entity.HasOne(e => e.Customer)
                      .WithMany(c => c.Accounts)
                      .HasForeignKey(e => e.CustomerId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // ProductType
            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.HasKey(e => e.ProductionTypeCode);
                entity.Property(e => e.ProductTypeDescription).HasMaxLength(100);
            });

            // Product
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId);
                entity.Property(e => e.ProductName).IsRequired().HasMaxLength(100);
                entity.HasOne(e => e.ProductType)
                      .WithMany(pt => pt.Products)
                      .HasForeignKey(e => e.ProductionTypeCode)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Order
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderId);
                entity.HasOne(e => e.Customer)
                      .WithMany(c => c.Orders)
                      .HasForeignKey(e => e.CustomerId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // OrderItem
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.OrderItemId);
                entity.HasOne(e => e.Order)
                      .WithMany(o => o.OrderItems)
                      .HasForeignKey(e => e.OrderId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.Product)
                      .WithMany()
                      .HasForeignKey(e => e.ProductId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Invoice
            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.InvoiceNumber);
                entity.HasOne(e => e.Order)
                      .WithOne(o => o.Invoice)
                      .HasForeignKey<Invoice>(e => e.OrderId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // InvoiceLineItem
            modelBuilder.Entity<InvoiceLineItem>(entity =>
            {
                entity.HasKey(e => e.InvoiceLineItemId);
                entity.HasOne(e => e.Invoice)
                      .WithMany(i => i.InvoiceLineItems)
                      .HasForeignKey(e => e.InvoiceNumber)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.Product)
                      .WithMany()
                      .HasForeignKey(e => e.ProductId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // FinancialTransaction
            modelBuilder.Entity<FinancialTransaction>(entity =>
            {
                entity.HasKey(e => e.TransactionId);
                entity.HasOne(e => e.Account)
                      .WithMany(a => a.FinancialTransactions)
                      .HasForeignKey(e => e.AccountId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.Invoice)
                      .WithMany()
                      .HasForeignKey(e => e.InvoiceNumber)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.TransactionType)
                      .WithMany(tt => tt.FinancialTransactions)
                      .HasForeignKey(e => e.TransactionTypeCode)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // TransactionType
            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.HasKey(e => e.TransactionTypeCode);
                entity.Property(e => e.TransactionTypeDescription).HasMaxLength(50);
            });
        }
    }
}
