﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BIMS.Models;

public partial class BIMSContext : IdentityDbContext<User, IdentityRole<int>, int>
{
    public BIMSContext()
    {
    }

    public BIMSContext(DbContextOptions<BIMSContext> options)
        : base(options)
    {
    }



    public virtual DbSet<Building> Buildings { get; set; }

    public virtual DbSet<BuildingEmployee> BuildingEmployees { get; set; }

    public virtual DbSet<BuildingType> BuildingTypes { get; set; }

    public virtual DbSet<BusinessArea> BusinessAreas { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<ChapaWebhookResponse> ChapaWebhookResponses { get; set; }
    public virtual DbSet<Chat> Chats { get; set; }

    public virtual DbSet<ChatStatus> ChatStatuses { get; set; }

    public virtual DbSet<ChatVersion> ChatVersions { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Documente> Documentes { get; set; }

    public virtual DbSet<Floor> Floors { get; set; }

    public virtual DbSet<FloorPrice> FloorPrices { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoiceStatus> InvoiceStatuses { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<ItemCategory> ItemCategories { get; set; }

    public virtual DbSet<ItemImage> ItemImages { get; set; }

    public virtual DbSet<ItemPrice> ItemPrices { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<MaintenanceRequest> MaintenanceRequests { get; set; }

    public virtual DbSet<MaintenanceStatus> MaintenanceStatuses { get; set; }

    public virtual DbSet<MaintenanceType> MaintenanceTypes { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<NotificationStatus> NotificationStatuses { get; set; }

    public virtual DbSet<NotificationType> NotificationTypes { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Owner> Owners { get; set; }

    public virtual DbSet<OwnershipType> OwnershipTypes { get; set; }

    public virtual DbSet<PaymentMode> PaymentModes { get; set; }

    public virtual DbSet<PaymentType> PaymentTypes { get; set; }

    public virtual DbSet<RentalAgreementTermination> RentalAgreementTerminations { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomPrice> RoomPrices { get; set; }

    public virtual DbSet<RoomProperty> RoomProperties { get; set; }

    public virtual DbSet<RoomPropertyType> RoomPropertyTypes { get; set; }

    public virtual DbSet<RoomPropertyTypeOption> RoomPropertyTypeOptions { get; set; }

    public virtual DbSet<RoomRental> RoomRentals { get; set; }

    public virtual DbSet<RoomRentalPayment> RoomRentalPayments { get; set; }

    public virtual DbSet<RoomStatue> RoomStatues { get; set; }

    public virtual DbSet<ServiceCategory> ServiceCategories { get; set; }

    public virtual DbSet<Shop> Shops { get; set; }

    public virtual DbSet<ShopLocation> ShopLocations { get; set; }

    public virtual DbSet<Tenant> Tenants { get; set; }

    public virtual DbSet<TenantType> TenantTypes { get; set; }

    public virtual DbSet<UseType> UseTypes { get; set; }

    public virtual new DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("name=BIMSConnection");


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        
        
        
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            // Set table names to lowercase (including AspNet Identity tables)
            var tableName = entity.GetTableName();
            entity.SetTableName(tableName.ToLower());

            // Set column names to lowercase
            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(property.Name.ToLower());
            }

            // Handle foreign key constraints as well (optional but recommended)
            foreach (var key in entity.GetKeys())
            {
                key.SetName(key.GetName().ToLower());
            }

            foreach (var fk in entity.GetForeignKeys())
            {
                fk.SetConstraintName(fk.GetConstraintName().ToLower());
            }

            foreach (var index in entity.GetIndexes())
            {
                index.SetDatabaseName(index.GetDatabaseName().ToLower());
            }
        }
        // Preserve exact case for tables

        base.OnModelCreating(modelBuilder);


        var dateTimeConverter = new ValueConverter<DateTime, DateTime>(
            v => v.ToUniversalTime(),
            v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

        var nullableDateTimeConverter = new ValueConverter<DateTime?, DateTime?>(
            v => v.HasValue ? v.Value.ToUniversalTime() : v,
            v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : v);

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType == typeof(DateTime))
                {
                    property.SetValueConverter(dateTimeConverter);
                }
                else if (property.ClrType == typeof(DateTime?))
                {
                    property.SetValueConverter(nullableDateTimeConverter);
                }
            }
        }

        modelBuilder.Entity<ChapaWebhookResponse>()
               .HasKey(c => c.Id); // This specifies that 'Id' is the primary key
        // Define primary key for IdentityUserLogin<string>
        modelBuilder.Entity<IdentityUserLogin<string>>()
            .HasKey(l => new { l.LoginProvider, l.ProviderKey });

        // Define primary key for IdentityUserToken<string>
        modelBuilder.Entity<IdentityUserToken<string>>()
            .HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

        modelBuilder.Entity<Building>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Table_1");

            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.BuildingType).WithMany(p => p.Buildings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Buildings_BuildingTypes");

            entity.HasOne(d => d.City).WithMany(p => p.Buildings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Buildings_Cities");

            entity.HasOne(d => d.Location).WithMany(p => p.Buildings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Buildings_Locations");

            entity.HasOne(d => d.Owner).WithMany(p => p.Buildings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Buildings_Owners");

            entity.HasOne(d => d.OwnershipType).WithMany(p => p.Buildings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Buildings_OwnershipTypes");

            entity.HasOne(d => d.UseType).WithMany(p => p.Buildings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Buildings_UseTypes");

            entity.HasOne(d => d.User).WithMany(p => p.Buildings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Buildings_Users");
        });

        modelBuilder.Entity<BuildingEmployee>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Building).WithMany(p => p.BuildingEmployees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BuildingEmployees_Buildings");

            entity.HasOne(d => d.ServiceCategory).WithMany(p => p.BuildingEmployees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BuildingEmployees_ServiceCategories");

            entity.HasOne(d => d.User).WithMany(p => p.BuildingEmployees).HasConstraintName("FK_BuildingEmployees_Users");
        });

        modelBuilder.Entity<BuildingType>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<BusinessArea>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

   
        modelBuilder.Entity<Cart>()
            .Property(c => c.TotalPrice)
            .HasPrecision(18, 2); // 18 total digits, 2 decimal places

        modelBuilder.Entity<Order>()
            .Property(o => o.TotalAmount)
            .HasPrecision(18, 2); // Define precision

        modelBuilder.Entity<OrderItem>()
            .Property(oi => oi.Price)
            .HasPrecision(18, 2); // Define precision


    // For PostgreSQL

        modelBuilder.Entity<Chat>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.ChatStatus).WithMany(p => p.Chats)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Chats_ChatStatuses");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Chats_Chats");

            entity.HasOne(d => d.Receiver).WithMany(p => p.ChatReceivers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Chats_Users1");

            entity.HasOne(d => d.Sender).WithMany(p => p.ChatSenders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Chats_Users");
        });

        modelBuilder.Entity<ChatStatus>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<ChatVersion>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Chat).WithMany(p => p.ChatVersions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChatVersions_Chats");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<Documente>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<Floor>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Building).WithMany(p => p.Floors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Floors_Buildings");
        });

        modelBuilder.Entity<FloorPrice>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Floor).WithMany(p => p.FloorPrices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FloorPrices_Floors");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.InvoiceStatus).WithMany(p => p.Invoices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoices_InvoiceStatuses");

            entity.HasOne(d => d.User).WithMany(p => p.Invoices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoices_Users");
        });

        modelBuilder.Entity<InvoiceStatus>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(i => i.DiscountPrice)
        .HasColumnType("decimal(18,2)");

            entity.HasOne(d => d.ItemCategory).WithMany(p => p.Items)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Items_ItemCategories");
        });

        modelBuilder.Entity<ItemCategory>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<ItemImage>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Item).WithMany(p => p.ItemImages)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ItemImages_Items");
        });

        modelBuilder.Entity<ItemPrice>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Item).WithMany(p => p.ItemPrices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ItemPrices_Items");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.City).WithMany(p => p.Locations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Locations_Cities");
        });

        modelBuilder.Entity<MaintenanceRequest>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.BuildingEmployee).WithMany(p => p.MaintenanceRequests)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MaintenanceRequests_BuildingEmployees");

            entity.HasOne(d => d.MaintenanceStatus).WithMany(p => p.MaintenanceRequests)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MaintenanceRequests_MaintenanceStatuses");

            entity.HasOne(d => d.MaintenanceType).WithMany(p => p.MaintenanceRequests)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MaintenanceRequests_MaintenanceTypes");

            entity.HasOne(d => d.Room).WithMany(p => p.MaintenanceRequests)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MaintenanceRequests_Rooms");

            entity.HasOne(d => d.User).WithMany(p => p.MaintenanceRequests)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MaintenanceRequests_Users");
        });

        modelBuilder.Entity<MaintenanceStatus>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<MaintenanceType>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.Property(e => e.IsRead).HasDefaultValue(true);

            entity.HasOne(d => d.NotificationStatus).WithMany(p => p.Notifications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notifications_NotificationStatuses");

            entity.HasOne(d => d.NotificationType).WithMany(p => p.Notifications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notifications_NotificationTypes");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notifications_AspNetUsers");
        });

        modelBuilder.Entity<NotificationStatus>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<NotificationType>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<Owner>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Document).WithMany(p => p.Owners)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Owners_Documentes");

            entity.HasOne(d => d.OwnershipType).WithMany(p => p.Owners)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Owners_OwnershipTypes");
        });

        modelBuilder.Entity<OwnershipType>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<PaymentMode>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<PaymentType>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<RentalAgreementTermination>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Document).WithMany(p => p.RentalAgreementTerminations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RentalAgreementTerminations_Documentes");

            entity.HasOne(d => d.RoomRental).WithMany(p => p.RentalAgreementTerminations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RentalAgreementTerminations_RoomRentals");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Floor).WithMany(p => p.Rooms)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rooms_Floors");

            entity.HasOne(d => d.RoomStatus).WithMany(p => p.Rooms)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rooms_RoomStatues");

            entity.HasOne(d => d.User).WithMany(p => p.Rooms)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rooms_Users");
        });

        modelBuilder.Entity<RoomPrice>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Room).WithMany(p => p.RoomPrices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoomPrices_Rooms");
        });

        modelBuilder.Entity<RoomProperty>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Room).WithMany(p => p.RoomProperties)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoomProperties_Rooms");

            entity.HasOne(d => d.RoomPropertyType).WithMany(p => p.RoomProperties)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoomProperties_RoomPropertyTypes");
        });

        modelBuilder.Entity<RoomPropertyType>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<RoomPropertyTypeOption>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.RoomPropertyType).WithMany(p => p.RoomPropertyTypeOptions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoomPropertyTypeOptions_RoomPropertyTypes");
        });

        modelBuilder.Entity<RoomRental>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.BusinessArea).WithMany(p => p.RoomRentals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoomRentals_BusinessAreas");

            entity.HasOne(d => d.Document).WithMany(p => p.RoomRentals).HasConstraintName("FK_RoomRentals_Documentes");

            entity.HasOne(d => d.Room).WithMany(p => p.RoomRentals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoomRentals_Rooms");

            entity.HasOne(d => d.Tenant).WithMany(p => p.RoomRentals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoomRentals_Tenants");
        });

        modelBuilder.Entity<RoomRentalPayment>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.PaymentMode).WithMany(p => p.RoomRentalPayments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoomRentalPayments_PaymentModes");

            entity.HasOne(d => d.PaymentType).WithMany(p => p.RoomRentalPayments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoomRentalPayments_PaymentTypes");

            entity.HasOne(d => d.RoomRental).WithMany(p => p.RoomRentalPayments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoomRentalPayments_RoomRentals");
        });

        modelBuilder.Entity<RoomStatue>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<ServiceCategory>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<Shop>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.BusinessArea).WithMany(p => p.Shops)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Shops_BusinessAreas");

            entity.HasOne(d => d.User).WithMany(p => p.Shops)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Shops_Users");
        });

        modelBuilder.Entity<ShopLocation>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Room).WithMany(p => p.ShopLocations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShopLocations_Rooms");

            entity.HasOne(d => d.Shop).WithMany(p => p.ShopLocations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShopLocations_Shops");
        });

        modelBuilder.Entity<Tenant>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.TenantType).WithMany(p => p.Tenants)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tenants_TenantTypes");
        });

        modelBuilder.Entity<TenantType>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<UseType>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });
     
        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id)
      .UseIdentityAlwaysColumn(); 

            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Gender).WithMany(p => p.Users)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Genders");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
