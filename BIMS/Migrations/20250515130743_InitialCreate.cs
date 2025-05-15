using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BIMS.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "\"BuildingType\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(name: "\"Name\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"BuildingType\"", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "\"BusinessArea\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(name: "\"Name\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"BusinessArea\"", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "\"ChapaWebhookResponse\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TxRef = table.Column<string>(name: "\"TxRef\"", type: "text", nullable: true),
                    Amount = table.Column<string>(name: "\"Amount\"", type: "text", nullable: true),
                    Status = table.Column<string>(name: "\"Status\"", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"ChapaWebhookResponse\"", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "\"ChatStatus\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(name: "\"Name\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"ChatStatus\"", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "\"City\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(name: "\"Name\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"City\"", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "\"Documente\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(name: "\"Name\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"Documente\"", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "\"Gender\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(name: "\"Name\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"Gender\"", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "\"InvoiceStatus\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(name: "\"Name\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"InvoiceStatus\"", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "\"ItemCategory\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(name: "\"Name\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"ItemCategory\"", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "\"MaintenanceStatus\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(name: "\"Name\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"MaintenanceStatus\"", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "\"MaintenanceType\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(name: "\"Name\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"MaintenanceType\"", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "\"NotificationStatus\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(name: "\"Name\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"NotificationStatus\"", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "\"NotificationType\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false),
                    Name = table.Column<string>(name: "\"Name\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"NotificationType\"", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "\"OwnershipType\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(name: "\"Name\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(name: "\"Description\"", type: "character varying(200)", maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"OwnershipType\"", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "\"PaymentMode\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(name: "\"Name\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"PaymentMode\"", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "\"PaymentType\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(name: "\"Name\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"PaymentType\"", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "\"RoomPropertyType\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(name: "\"Name\"", type: "character varying(30)", maxLength: 30, nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"RoomPropertyType\"", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "\"RoomStatue\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(name: "\"Name\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"RoomStatue\"", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "\"ServiceCategory\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(name: "\"Name\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"ServiceCategory\"", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "\"TenantType\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(name: "\"Name\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"TenantType\"", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "\"UseType\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(name: "\"Name\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(name: "\"Description\"", type: "character varying(200)", maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"UseType\"", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(name: "\"Name\"", type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(name: "\"NormalizedName\"", type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(name: "\"ConcurrencyStamp\"", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserLogin<string>",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserLogin<string>", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserToken<string>",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserToken<string>", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "\"Location\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(name: "\"Name\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    Coordinates = table.Column<string>(name: "\"Coordinates\"", type: "character varying(50)", maxLength: 50, nullable: true),
                    CityId = table.Column<int>(name: "\"CityId\"", type: "integer", nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"Location\"", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Cities",
                        column: x => x.CityId,
                        principalTable: "\"City\"",
                        principalColumn: "\"Id\"");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    OwnerId = table.Column<int>(name: "\"OwnerId\"", type: "integer", nullable: true),
                    GenderId = table.Column<int>(name: "\"GenderId\"", type: "integer", nullable: false),
                    FirstName = table.Column<string>(name: "\"FirstName\"", type: "character varying(30)", maxLength: 30, nullable: false),
                    MiddleName = table.Column<string>(name: "\"MiddleName\"", type: "character varying(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(name: "\"LastName\"", type: "character varying(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(name: "\"Email\"", type: "character varying(256)", maxLength: 256, nullable: false),
                    PhoneNumber = table.Column<string>(name: "\"PhoneNumber\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateOnly>(name: "\"CreatedDate\"", type: "date", nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false),
                    Password = table.Column<string>(name: "\"Password\"", type: "character varying(30)", maxLength: 30, nullable: false),
                    UserName = table.Column<string>(name: "\"UserName\"", type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(name: "\"NormalizedUserName\"", type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(name: "\"NormalizedEmail\"", type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(name: "\"EmailConfirmed\"", type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(name: "\"PasswordHash\"", type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(name: "\"SecurityStamp\"", type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(name: "\"ConcurrencyStamp\"", type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(name: "\"PhoneNumberConfirmed\"", type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(name: "\"TwoFactorEnabled\"", type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(name: "\"LockoutEnd\"", type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(name: "\"LockoutEnabled\"", type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(name: "\"AccessFailedCount\"", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Genders",
                        column: x => x.GenderId,
                        principalTable: "\"Gender\"",
                        principalColumn: "\"Id\"");
                });

            migrationBuilder.CreateTable(
                name: "\"RoomPropertyTypeOption\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomPropertyTypeId = table.Column<int>(name: "\"RoomPropertyTypeId\"", type: "integer", nullable: false),
                    Name = table.Column<string>(name: "\"Name\"", type: "character varying(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"RoomPropertyTypeOption\"", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomPropertyTypeOptions_RoomPropertyTypes",
                        column: x => x.RoomPropertyTypeId,
                        principalTable: "\"RoomPropertyType\"",
                        principalColumn: "\"Id\"");
                });

            migrationBuilder.CreateTable(
                name: "\"Tenant\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(name: "\"Name\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(name: "\"Description\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    Contact = table.Column<string>(name: "\"Contact\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    TenantTypeId = table.Column<int>(name: "\"TenantTypeId\"", type: "integer", nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"Tenant\"", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tenants_TenantTypes",
                        column: x => x.TenantTypeId,
                        principalTable: "\"TenantType\"",
                        principalColumn: "\"Id\"");
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<int>(name: "\"RoleId\"", type: "integer", nullable: false),
                    ClaimType = table.Column<string>(name: "\"ClaimType\"", type: "text", nullable: true),
                    ClaimValue = table.Column<string>(name: "\"ClaimValue\"", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_\"RoleId\"",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "\"Id\"",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "\"Chat\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SenderId = table.Column<int>(name: "\"SenderId\"", type: "integer", nullable: false),
                    ReceiverId = table.Column<int>(name: "\"ReceiverId\"", type: "integer", nullable: false),
                    ParentId = table.Column<int>(name: "\"ParentId\"", type: "integer", nullable: true),
                    Message = table.Column<string>(name: "\"Message\"", type: "character varying(150)", maxLength: 150, nullable: false),
                    ChatStatusId = table.Column<int>(name: "\"ChatStatusId\"", type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(name: "\"Date\"", type: "date", nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"Chat\"", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chats_ChatStatuses",
                        column: x => x.ChatStatusId,
                        principalTable: "\"ChatStatus\"",
                        principalColumn: "\"Id\"");
                    table.ForeignKey(
                        name: "FK_Chats_Chats",
                        column: x => x.ParentId,
                        principalTable: "\"Chat\"",
                        principalColumn: "\"Id\"");
                    table.ForeignKey(
                        name: "FK_Chats_Users",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "\"Id\"");
                    table.ForeignKey(
                        name: "FK_Chats_Users1",
                        column: x => x.ReceiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "\"Id\"");
                });

            migrationBuilder.CreateTable(
                name: "\"Invoice\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(name: "\"UserId\"", type: "integer", nullable: false),
                    InvoiceStatusId = table.Column<int>(name: "\"InvoiceStatusId\"", type: "integer", nullable: false),
                    Amount = table.Column<double>(name: "\"Amount\"", type: "double precision", nullable: false),
                    InvoiceDate = table.Column<DateOnly>(name: "\"InvoiceDate\"", type: "date", nullable: false),
                    DueDate = table.Column<DateOnly>(name: "\"DueDate\"", type: "date", nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"Invoice\"", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_InvoiceStatuses",
                        column: x => x.InvoiceStatusId,
                        principalTable: "\"InvoiceStatus\"",
                        principalColumn: "\"Id\"");
                    table.ForeignKey(
                        name: "FK_Invoices_Users",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "\"Id\"");
                });

            migrationBuilder.CreateTable(
                name: "\"Notification\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Message = table.Column<string>(name: "\"Message\"", type: "text", nullable: true),
                    TempColumn = table.Column<bool>(name: "\"TempColumn\"", type: "boolean", nullable: false),
                    UserId = table.Column<int>(name: "\"UserId\"", type: "integer", nullable: false),
                    NotificationTypeId = table.Column<int>(name: "\"NotificationTypeId\"", type: "integer", nullable: false),
                    NotificationStatusId = table.Column<int>(name: "\"NotificationStatusId\"", type: "integer", nullable: false),
                    NotificationDate = table.Column<DateTime>(name: "\"NotificationDate\"", type: "timestamp with time zone", nullable: false),
                    IsRead = table.Column<bool>(name: "\"IsRead\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"Notification\"", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "\"Id\"");
                    table.ForeignKey(
                        name: "FK_Notifications_NotificationStatuses",
                        column: x => x.NotificationStatusId,
                        principalTable: "\"NotificationStatus\"",
                        principalColumn: "\"Id\"");
                    table.ForeignKey(
                        name: "FK_Notifications_NotificationTypes",
                        column: x => x.NotificationTypeId,
                        principalTable: "\"NotificationType\"",
                        principalColumn: "\"Id\"");
                });

            migrationBuilder.CreateTable(
                name: "\"Order\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(name: "\"UserId\"", type: "integer", nullable: false),
                    OrderDate = table.Column<DateTime>(name: "\"OrderDate\"", type: "timestamp with time zone", nullable: false),
                    TotalAmount = table.Column<decimal>(name: "\"TotalAmount\"", type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    ShippingAddress = table.Column<string>(name: "\"ShippingAddress\"", type: "text", nullable: true),
                    TransactionRef = table.Column<string>(name: "\"TransactionRef\"", type: "text", nullable: true),
                    Status = table.Column<string>(name: "\"Status\"", type: "text", nullable: true),
                    PaymentStatus = table.Column<string>(name: "\"PaymentStatus\"", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"Order\"", x => x.Id);
                    table.ForeignKey(
                        name: "FK_\"Order\"_AspNetUsers_\"UserId\"",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "\"Id\"",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "\"Owner\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(name: "\"UserId\"", type: "integer", nullable: false),
                    FullName = table.Column<string>(name: "\"FullName\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    OwnershipTypeId = table.Column<int>(name: "\"OwnershipTypeId\"", type: "integer", nullable: false),
                    Tin = table.Column<int>(name: "\"Tin\"", type: "integer", nullable: false),
                    DocumentId = table.Column<int>(name: "\"DocumentId\"", type: "integer", nullable: true),
                    Verified = table.Column<bool>(name: "\"Verified\"", type: "boolean", nullable: false),
                    BankName = table.Column<string>(name: "\"BankName\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    RegisteredDate = table.Column<DateOnly>(name: "\"RegisteredDate\"", type: "date", nullable: false),
                    License = table.Column<string>(name: "\"License\"", type: "character varying(255)", maxLength: 255, nullable: true),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    BankAccountNumber = table.Column<string>(name: "\"BankAccountNumber\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"Owner\"", x => x.Id);
                    table.ForeignKey(
                        name: "FK_\"Owner\"_AspNetUsers_\"UserId\"",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "\"Id\"",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Owners_Documentes",
                        column: x => x.DocumentId,
                        principalTable: "\"Documente\"",
                        principalColumn: "\"Id\"");
                    table.ForeignKey(
                        name: "FK_Owners_OwnershipTypes",
                        column: x => x.OwnershipTypeId,
                        principalTable: "\"OwnershipType\"",
                        principalColumn: "\"Id\"");
                });

            migrationBuilder.CreateTable(
                name: "\"Shop\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(name: "\"Name\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    UserId = table.Column<int>(name: "\"UserId\"", type: "integer", nullable: false),
                    BusinessAreaId = table.Column<int>(name: "\"BusinessAreaId\"", type: "integer", nullable: false),
                    Description = table.Column<string>(name: "\"Description\"", type: "character varying(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false),
                    ImageUrl = table.Column<string>(name: "\"ImageUrl\"", type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"Shop\"", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shops_BusinessAreas",
                        column: x => x.BusinessAreaId,
                        principalTable: "\"BusinessArea\"",
                        principalColumn: "\"Id\"");
                    table.ForeignKey(
                        name: "FK_Shops_Users",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "\"Id\"");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(name: "\"UserId\"", type: "integer", nullable: false),
                    ClaimType = table.Column<string>(name: "\"ClaimType\"", type: "text", nullable: true),
                    ClaimValue = table.Column<string>(name: "\"ClaimValue\"", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_\"UserId\"",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "\"Id\"",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(name: "\"LoginProvider\"", type: "text", nullable: false),
                    ProviderKey = table.Column<string>(name: "\"ProviderKey\"", type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(name: "\"ProviderDisplayName\"", type: "text", nullable: true),
                    UserId = table.Column<int>(name: "\"UserId\"", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_\"UserId\"",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "\"Id\"",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(name: "\"UserId\"", type: "integer", nullable: false),
                    RoleId = table.Column<int>(name: "\"RoleId\"", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_\"RoleId\"",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "\"Id\"",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_\"UserId\"",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "\"Id\"",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(name: "\"UserId\"", type: "integer", nullable: false),
                    LoginProvider = table.Column<string>(name: "\"LoginProvider\"", type: "text", nullable: false),
                    Name = table.Column<string>(name: "\"Name\"", type: "text", nullable: false),
                    Value = table.Column<string>(name: "\"Value\"", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_\"UserId\"",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "\"Id\"",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "\"ChatVersion\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChatId = table.Column<int>(name: "\"ChatId\"", type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(name: "\"Date\"", type: "date", nullable: false),
                    OldMessage = table.Column<string>(name: "\"OldMessage\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"ChatVersion\"", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatVersions_Chats",
                        column: x => x.ChatId,
                        principalTable: "\"Chat\"",
                        principalColumn: "\"Id\"");
                });

            migrationBuilder.CreateTable(
                name: "\"Building\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UseTypeId = table.Column<int>(name: "\"UseTypeId\"", type: "integer", nullable: false),
                    UserId = table.Column<int>(name: "\"UserId\"", type: "integer", nullable: false),
                    CityId = table.Column<int>(name: "\"CityId\"", type: "integer", nullable: false),
                    LocationId = table.Column<int>(name: "\"LocationId\"", type: "integer", nullable: false),
                    Name = table.Column<string>(name: "\"Name\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(name: "\"Description\"", type: "character varying(200)", maxLength: 200, nullable: false),
                    ConstractionYear = table.Column<string>(name: "\"ConstractionYear\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    NumberOfFloor = table.Column<int>(name: "\"NumberOfFloor\"", type: "integer", nullable: false),
                    BuildingTypeId = table.Column<int>(name: "\"BuildingTypeId\"", type: "integer", nullable: false),
                    OwnershipTypeId = table.Column<int>(name: "\"OwnershipTypeId\"", type: "integer", nullable: false),
                    OwnerId = table.Column<int>(name: "\"OwnerId\"", type: "integer", nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buildings_BuildingTypes",
                        column: x => x.BuildingTypeId,
                        principalTable: "\"BuildingType\"",
                        principalColumn: "\"Id\"");
                    table.ForeignKey(
                        name: "FK_Buildings_Cities",
                        column: x => x.CityId,
                        principalTable: "\"City\"",
                        principalColumn: "\"Id\"");
                    table.ForeignKey(
                        name: "FK_Buildings_Locations",
                        column: x => x.LocationId,
                        principalTable: "\"Location\"",
                        principalColumn: "\"Id\"");
                    table.ForeignKey(
                        name: "FK_Buildings_Owners",
                        column: x => x.OwnerId,
                        principalTable: "\"Owner\"",
                        principalColumn: "\"Id\"");
                    table.ForeignKey(
                        name: "FK_Buildings_OwnershipTypes",
                        column: x => x.OwnershipTypeId,
                        principalTable: "\"OwnershipType\"",
                        principalColumn: "\"Id\"");
                    table.ForeignKey(
                        name: "FK_Buildings_UseTypes",
                        column: x => x.UseTypeId,
                        principalTable: "\"UseType\"",
                        principalColumn: "\"Id\"");
                    table.ForeignKey(
                        name: "FK_Buildings_Users",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "\"Id\"");
                });

            migrationBuilder.CreateTable(
                name: "\"Item\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(name: "\"Name\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    ItemCategoryId = table.Column<int>(name: "\"ItemCategoryId\"", type: "integer", nullable: false),
                    IsAvailable = table.Column<bool>(name: "\"IsAvailable\"", type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false),
                    Stock = table.Column<int>(name: "\"Stock\"", type: "integer", nullable: false),
                    DiscountPrice = table.Column<decimal>(name: "\"DiscountPrice\"", type: "numeric(18,2)", nullable: false),
                    SalesCount = table.Column<int>(name: "\"SalesCount\"", type: "integer", nullable: false),
                    ImagePath = table.Column<string>(name: "\"ImagePath\"", type: "text", nullable: true),
                    Price = table.Column<decimal>(name: "\"Price\"", type: "numeric(18,2)", nullable: false),
                    ShopId = table.Column<int>(name: "\"ShopId\"", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"Item\"", x => x.Id);
                    table.ForeignKey(
                        name: "FK_\"Item\"_\"Shop\"_\"ShopId\"",
                        column: x => x.ShopId,
                        principalTable: "\"Shop\"",
                        principalColumn: "\"Id\"",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_ItemCategories",
                        column: x => x.ItemCategoryId,
                        principalTable: "\"ItemCategory\"",
                        principalColumn: "\"Id\"");
                });

            migrationBuilder.CreateTable(
                name: "\"BuildingEmployee\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(name: "\"FullName\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(name: "\"PhoneNumber\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    BuildingId = table.Column<int>(name: "\"BuildingId\"", type: "integer", nullable: false),
                    UserId = table.Column<int>(name: "\"UserId\"", type: "integer", nullable: true),
                    ServiceCategoryId = table.Column<int>(name: "\"ServiceCategoryId\"", type: "integer", nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"BuildingEmployee\"", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildingEmployees_Buildings",
                        column: x => x.BuildingId,
                        principalTable: "\"Building\"",
                        principalColumn: "\"Id\"");
                    table.ForeignKey(
                        name: "FK_BuildingEmployees_ServiceCategories",
                        column: x => x.ServiceCategoryId,
                        principalTable: "\"ServiceCategory\"",
                        principalColumn: "\"Id\"");
                    table.ForeignKey(
                        name: "FK_BuildingEmployees_Users",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "\"Id\"");
                });

            migrationBuilder.CreateTable(
                name: "\"Floor\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(name: "\"Name\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    BuildingId = table.Column<int>(name: "\"BuildingId\"", type: "integer", nullable: false),
                    NumberOfRoom = table.Column<string>(name: "\"NumberOfRoom\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"Floor\"", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Floors_Buildings",
                        column: x => x.BuildingId,
                        principalTable: "\"Building\"",
                        principalColumn: "\"Id\"");
                });

            migrationBuilder.CreateTable(
                name: "\"Cart\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(name: "\"UserId\"", type: "integer", nullable: false),
                    ItemId = table.Column<int>(name: "\"ItemId\"", type: "integer", nullable: false),
                    Quantity = table.Column<int>(name: "\"Quantity\"", type: "integer", nullable: false),
                    TotalPrice = table.Column<decimal>(name: "\"TotalPrice\"", type: "numeric(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"Cart\"", x => x.Id);
                    table.ForeignKey(
                        name: "FK_\"Cart\"_\"Item\"_\"ItemId\"",
                        column: x => x.ItemId,
                        principalTable: "\"Item\"",
                        principalColumn: "\"Id\"",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_\"Cart\"_AspNetUsers_\"UserId\"",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "\"Id\"",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "\"ItemImage\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemId = table.Column<int>(name: "\"ItemId\"", type: "integer", nullable: false),
                    Url = table.Column<string>(name: "\"Url\"", type: "character varying(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"ItemImage\"", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemImages_Items",
                        column: x => x.ItemId,
                        principalTable: "\"Item\"",
                        principalColumn: "\"Id\"");
                });

            migrationBuilder.CreateTable(
                name: "\"ItemPrice\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemId = table.Column<int>(name: "\"ItemId\"", type: "integer", nullable: false),
                    AppliedDate = table.Column<DateOnly>(name: "\"AppliedDate\"", type: "date", nullable: true),
                    MinPrice = table.Column<double>(name: "\"MinPrice\"", type: "double precision", nullable: false),
                    MaxPrice = table.Column<double>(name: "\"MaxPrice\"", type: "double precision", nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"ItemPrice\"", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemPrices_Items",
                        column: x => x.ItemId,
                        principalTable: "\"Item\"",
                        principalColumn: "\"Id\"");
                });

            migrationBuilder.CreateTable(
                name: "\"OrderItem\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(name: "\"OrderId\"", type: "integer", nullable: false),
                    ItemId = table.Column<int>(name: "\"ItemId\"", type: "integer", nullable: false),
                    Quantity = table.Column<int>(name: "\"Quantity\"", type: "integer", nullable: false),
                    Price = table.Column<decimal>(name: "\"Price\"", type: "numeric(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"OrderItem\"", x => x.Id);
                    table.ForeignKey(
                        name: "FK_\"OrderItem\"_\"Item\"_\"ItemId\"",
                        column: x => x.ItemId,
                        principalTable: "\"Item\"",
                        principalColumn: "\"Id\"",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_\"OrderItem\"_\"Order\"_\"OrderId\"",
                        column: x => x.OrderId,
                        principalTable: "\"Order\"",
                        principalColumn: "\"Id\"",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "\"FloorPrice\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FloorId = table.Column<int>(name: "\"FloorId\"", type: "integer", nullable: false),
                    Name = table.Column<string>(name: "\"Name\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    Price = table.Column<double>(name: "\"Price\"", type: "double precision", nullable: false),
                    AppliedDate = table.Column<DateOnly>(name: "\"AppliedDate\"", type: "date", nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: true, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"FloorPrice\"", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FloorPrices_Floors",
                        column: x => x.FloorId,
                        principalTable: "\"Floor\"",
                        principalColumn: "\"Id\"");
                });

            migrationBuilder.CreateTable(
                name: "\"Room\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(name: "\"Name\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    FloorId = table.Column<int>(name: "\"FloorId\"", type: "integer", nullable: false),
                    UserId = table.Column<int>(name: "\"UserId\"", type: "integer", nullable: false),
                    RoomStatusId = table.Column<int>(name: "\"RoomStatusId\"", type: "integer", nullable: false),
                    SizeInm2 = table.Column<int>(name: "\"SizeInm2\"", type: "integer", nullable: false),
                    Width = table.Column<double>(name: "\"Width\"", type: "double precision", nullable: false),
                    Length = table.Column<double>(name: "\"Length\"", type: "double precision", nullable: false),
                    Description = table.Column<string>(name: "\"Description\"", type: "character varying(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"Room\"", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Floors",
                        column: x => x.FloorId,
                        principalTable: "\"Floor\"",
                        principalColumn: "\"Id\"");
                    table.ForeignKey(
                        name: "FK_Rooms_RoomStatues",
                        column: x => x.RoomStatusId,
                        principalTable: "\"RoomStatue\"",
                        principalColumn: "\"Id\"");
                    table.ForeignKey(
                        name: "FK_Rooms_Users",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "\"Id\"");
                });

            migrationBuilder.CreateTable(
                name: "\"MaintenanceRequest\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(name: "\"UserId\"", type: "integer", nullable: false),
                    RoomId = table.Column<int>(name: "\"RoomId\"", type: "integer", nullable: false),
                    MaintenanceTypeId = table.Column<int>(name: "\"MaintenanceTypeId\"", type: "integer", nullable: false),
                    BuildingEmployeeId = table.Column<int>(name: "\"BuildingEmployeeId\"", type: "integer", nullable: false),
                    MaintenanceStatusId = table.Column<int>(name: "\"MaintenanceStatusId\"", type: "integer", nullable: false),
                    Description = table.Column<string>(name: "\"Description\"", type: "character varying(150)", maxLength: 150, nullable: false),
                    DateSubmitted = table.Column<DateOnly>(name: "\"DateSubmitted\"", type: "date", nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"MaintenanceRequest\"", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceRequests_BuildingEmployees",
                        column: x => x.BuildingEmployeeId,
                        principalTable: "\"BuildingEmployee\"",
                        principalColumn: "\"Id\"");
                    table.ForeignKey(
                        name: "FK_MaintenanceRequests_MaintenanceStatuses",
                        column: x => x.MaintenanceStatusId,
                        principalTable: "\"MaintenanceStatus\"",
                        principalColumn: "\"Id\"");
                    table.ForeignKey(
                        name: "FK_MaintenanceRequests_MaintenanceTypes",
                        column: x => x.MaintenanceTypeId,
                        principalTable: "\"MaintenanceType\"",
                        principalColumn: "\"Id\"");
                    table.ForeignKey(
                        name: "FK_MaintenanceRequests_Rooms",
                        column: x => x.RoomId,
                        principalTable: "\"Room\"",
                        principalColumn: "\"Id\"");
                    table.ForeignKey(
                        name: "FK_MaintenanceRequests_Users",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "\"Id\"");
                });

            migrationBuilder.CreateTable(
                name: "\"RoomPrice\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomId = table.Column<int>(name: "\"RoomId\"", type: "integer", nullable: false),
                    PricePerM2 = table.Column<double>(name: "\"PricePerM2\"", type: "double precision", nullable: false),
                    AppliedDate = table.Column<DateOnly>(name: "\"AppliedDate\"", type: "date", nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"RoomPrice\"", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomPrices_Rooms",
                        column: x => x.RoomId,
                        principalTable: "\"Room\"",
                        principalColumn: "\"Id\"");
                });

            migrationBuilder.CreateTable(
                name: "\"RoomProperty\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomId = table.Column<int>(name: "\"RoomId\"", type: "integer", nullable: false),
                    RoomPropertyTypeId = table.Column<int>(name: "\"RoomPropertyTypeId\"", type: "integer", nullable: false),
                    Value = table.Column<string>(name: "\"Value\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"RoomProperty\"", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomProperties_RoomPropertyTypes",
                        column: x => x.RoomPropertyTypeId,
                        principalTable: "\"RoomPropertyType\"",
                        principalColumn: "\"Id\"");
                    table.ForeignKey(
                        name: "FK_RoomProperties_Rooms",
                        column: x => x.RoomId,
                        principalTable: "\"Room\"",
                        principalColumn: "\"Id\"");
                });

            migrationBuilder.CreateTable(
                name: "\"RoomRental\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomId = table.Column<int>(name: "\"RoomId\"", type: "integer", nullable: false),
                    TenantId = table.Column<int>(name: "\"TenantId\"", type: "integer", nullable: false),
                    TotalPrice = table.Column<double>(name: "\"TotalPrice\"", type: "double precision", nullable: false),
                    StartDate = table.Column<DateOnly>(name: "\"StartDate\"", type: "date", nullable: false),
                    BusinessAreaId = table.Column<int>(name: "\"BusinessAreaId\"", type: "integer", nullable: false),
                    DocumentId = table.Column<int>(name: "\"DocumentId\"", type: "integer", nullable: true),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"RoomRental\"", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomRentals_BusinessAreas",
                        column: x => x.BusinessAreaId,
                        principalTable: "\"BusinessArea\"",
                        principalColumn: "\"Id\"");
                    table.ForeignKey(
                        name: "FK_RoomRentals_Documentes",
                        column: x => x.DocumentId,
                        principalTable: "\"Documente\"",
                        principalColumn: "\"Id\"");
                    table.ForeignKey(
                        name: "FK_RoomRentals_Rooms",
                        column: x => x.RoomId,
                        principalTable: "\"Room\"",
                        principalColumn: "\"Id\"");
                    table.ForeignKey(
                        name: "FK_RoomRentals_Tenants",
                        column: x => x.TenantId,
                        principalTable: "\"Tenant\"",
                        principalColumn: "\"Id\"");
                });

            migrationBuilder.CreateTable(
                name: "\"ShopLocation\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(name: "\"Name\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    RoomId = table.Column<int>(name: "\"RoomId\"", type: "integer", nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false),
                    ShopId = table.Column<int>(name: "\"ShopId\"", type: "integer", nullable: false),
                    CreatedDate = table.Column<DateOnly>(name: "\"CreatedDate\"", type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"ShopLocation\"", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopLocations_Rooms",
                        column: x => x.RoomId,
                        principalTable: "\"Room\"",
                        principalColumn: "\"Id\"");
                    table.ForeignKey(
                        name: "FK_ShopLocations_Shops",
                        column: x => x.ShopId,
                        principalTable: "\"Shop\"",
                        principalColumn: "\"Id\"");
                });

            migrationBuilder.CreateTable(
                name: "\"RentalAgreementTermination\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomRentalId = table.Column<int>(name: "\"RoomRentalId\"", type: "integer", nullable: false),
                    Reason = table.Column<string>(name: "\"Reason\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    DocumentId = table.Column<int>(name: "\"DocumentId\"", type: "integer", nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"RentalAgreementTermination\"", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentalAgreementTerminations_Documentes",
                        column: x => x.DocumentId,
                        principalTable: "\"Documente\"",
                        principalColumn: "\"Id\"");
                    table.ForeignKey(
                        name: "FK_RentalAgreementTerminations_RoomRentals",
                        column: x => x.RoomRentalId,
                        principalTable: "\"RoomRental\"",
                        principalColumn: "\"Id\"");
                });

            migrationBuilder.CreateTable(
                name: "\"RoomRentalPayment\"",
                columns: table => new
                {
                    Id = table.Column<int>(name: "\"Id\"", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomRentalId = table.Column<int>(name: "\"RoomRentalId\"", type: "integer", nullable: false),
                    PaymentTypeId = table.Column<int>(name: "\"PaymentTypeId\"", type: "integer", nullable: false),
                    PaymentModeId = table.Column<int>(name: "\"PaymentModeId\"", type: "integer", nullable: false),
                    PaidDate = table.Column<DateOnly>(name: "\"PaidDate\"", type: "date", nullable: false),
                    TotalAmount = table.Column<double>(name: "\"TotalAmount\"", type: "double precision", nullable: false),
                    InvoiceNumber = table.Column<string>(name: "\"InvoiceNumber\"", type: "character varying(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(name: "\"IsActive\"", type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(name: "\"IsDeleted\"", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_\"RoomRentalPayment\"", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomRentalPayments_PaymentModes",
                        column: x => x.PaymentModeId,
                        principalTable: "\"PaymentMode\"",
                        principalColumn: "\"Id\"");
                    table.ForeignKey(
                        name: "FK_RoomRentalPayments_PaymentTypes",
                        column: x => x.PaymentTypeId,
                        principalTable: "\"PaymentType\"",
                        principalColumn: "\"Id\"");
                    table.ForeignKey(
                        name: "FK_RoomRentalPayments_RoomRentals",
                        column: x => x.RoomRentalId,
                        principalTable: "\"RoomRental\"",
                        principalColumn: "\"Id\"");
                });

            migrationBuilder.CreateIndex(
                name: "IX_\"Building\"_\"BuildingTypeId\"",
                table: "\"Building\"",
                column: "\"BuildingTypeId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"Building\"_\"CityId\"",
                table: "\"Building\"",
                column: "\"CityId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"Building\"_\"LocationId\"",
                table: "\"Building\"",
                column: "\"LocationId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"Building\"_\"OwnerId\"",
                table: "\"Building\"",
                column: "\"OwnerId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"Building\"_\"OwnershipTypeId\"",
                table: "\"Building\"",
                column: "\"OwnershipTypeId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"Building\"_\"UserId\"",
                table: "\"Building\"",
                column: "\"UserId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"Building\"_\"UseTypeId\"",
                table: "\"Building\"",
                column: "\"UseTypeId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"BuildingEmployee\"_\"BuildingId\"",
                table: "\"BuildingEmployee\"",
                column: "\"BuildingId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"BuildingEmployee\"_\"ServiceCategoryId\"",
                table: "\"BuildingEmployee\"",
                column: "\"ServiceCategoryId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"BuildingEmployee\"_\"UserId\"",
                table: "\"BuildingEmployee\"",
                column: "\"UserId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"Cart\"_\"ItemId\"",
                table: "\"Cart\"",
                column: "\"ItemId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"Cart\"_\"UserId\"",
                table: "\"Cart\"",
                column: "\"UserId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"Chat\"_\"ChatStatusId\"",
                table: "\"Chat\"",
                column: "\"ChatStatusId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"Chat\"_\"ParentId\"",
                table: "\"Chat\"",
                column: "\"ParentId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"Chat\"_\"ReceiverId\"",
                table: "\"Chat\"",
                column: "\"ReceiverId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"Chat\"_\"SenderId\"",
                table: "\"Chat\"",
                column: "\"SenderId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"ChatVersion\"_\"ChatId\"",
                table: "\"ChatVersion\"",
                column: "\"ChatId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"Floor\"_\"BuildingId\"",
                table: "\"Floor\"",
                column: "\"BuildingId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"FloorPrice\"_\"FloorId\"",
                table: "\"FloorPrice\"",
                column: "\"FloorId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"Invoice\"_\"InvoiceStatusId\"",
                table: "\"Invoice\"",
                column: "\"InvoiceStatusId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"Invoice\"_\"UserId\"",
                table: "\"Invoice\"",
                column: "\"UserId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"Item\"_\"ItemCategoryId\"",
                table: "\"Item\"",
                column: "\"ItemCategoryId\"");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ShopId",
                table: "\"Item\"",
                column: "\"ShopId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"ItemImage\"_\"ItemId\"",
                table: "\"ItemImage\"",
                column: "\"ItemId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"ItemPrice\"_\"ItemId\"",
                table: "\"ItemPrice\"",
                column: "\"ItemId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"Location\"_\"CityId\"",
                table: "\"Location\"",
                column: "\"CityId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"MaintenanceRequest\"_\"BuildingEmployeeId\"",
                table: "\"MaintenanceRequest\"",
                column: "\"BuildingEmployeeId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"MaintenanceRequest\"_\"MaintenanceStatusId\"",
                table: "\"MaintenanceRequest\"",
                column: "\"MaintenanceStatusId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"MaintenanceRequest\"_\"MaintenanceTypeId\"",
                table: "\"MaintenanceRequest\"",
                column: "\"MaintenanceTypeId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"MaintenanceRequest\"_\"RoomId\"",
                table: "\"MaintenanceRequest\"",
                column: "\"RoomId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"MaintenanceRequest\"_\"UserId\"",
                table: "\"MaintenanceRequest\"",
                column: "\"UserId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"Notification\"_\"NotificationStatusId\"",
                table: "\"Notification\"",
                column: "\"NotificationStatusId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"Notification\"_\"NotificationTypeId\"",
                table: "\"Notification\"",
                column: "\"NotificationTypeId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"Notification\"_\"UserId\"",
                table: "\"Notification\"",
                column: "\"UserId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"Order\"_\"UserId\"",
                table: "\"Order\"",
                column: "\"UserId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"OrderItem\"_\"ItemId\"",
                table: "\"OrderItem\"",
                column: "\"ItemId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"OrderItem\"_\"OrderId\"",
                table: "\"OrderItem\"",
                column: "\"OrderId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"Owner\"_\"DocumentId\"",
                table: "\"Owner\"",
                column: "\"DocumentId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"Owner\"_\"OwnershipTypeId\"",
                table: "\"Owner\"",
                column: "\"OwnershipTypeId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"Owner\"_\"UserId\"",
                table: "\"Owner\"",
                column: "\"UserId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"RentalAgreementTermination\"_\"DocumentId\"",
                table: "\"RentalAgreementTermination\"",
                column: "\"DocumentId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"RentalAgreementTermination\"_\"RoomRentalId\"",
                table: "\"RentalAgreementTermination\"",
                column: "\"RoomRentalId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"Room\"_\"FloorId\"",
                table: "\"Room\"",
                column: "\"FloorId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"Room\"_\"RoomStatusId\"",
                table: "\"Room\"",
                column: "\"RoomStatusId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"Room\"_\"UserId\"",
                table: "\"Room\"",
                column: "\"UserId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"RoomPrice\"_\"RoomId\"",
                table: "\"RoomPrice\"",
                column: "\"RoomId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"RoomProperty\"_\"RoomId\"",
                table: "\"RoomProperty\"",
                column: "\"RoomId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"RoomProperty\"_\"RoomPropertyTypeId\"",
                table: "\"RoomProperty\"",
                column: "\"RoomPropertyTypeId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"RoomPropertyTypeOption\"_\"RoomPropertyTypeId\"",
                table: "\"RoomPropertyTypeOption\"",
                column: "\"RoomPropertyTypeId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"RoomRental\"_\"BusinessAreaId\"",
                table: "\"RoomRental\"",
                column: "\"BusinessAreaId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"RoomRental\"_\"DocumentId\"",
                table: "\"RoomRental\"",
                column: "\"DocumentId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"RoomRental\"_\"RoomId\"",
                table: "\"RoomRental\"",
                column: "\"RoomId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"RoomRental\"_\"TenantId\"",
                table: "\"RoomRental\"",
                column: "\"TenantId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"RoomRentalPayment\"_\"PaymentModeId\"",
                table: "\"RoomRentalPayment\"",
                column: "\"PaymentModeId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"RoomRentalPayment\"_\"PaymentTypeId\"",
                table: "\"RoomRentalPayment\"",
                column: "\"PaymentTypeId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"RoomRentalPayment\"_\"RoomRentalId\"",
                table: "\"RoomRentalPayment\"",
                column: "\"RoomRentalId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"Shop\"_\"BusinessAreaId\"",
                table: "\"Shop\"",
                column: "\"BusinessAreaId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"Shop\"_\"UserId\"",
                table: "\"Shop\"",
                column: "\"UserId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"ShopLocation\"_\"RoomId\"",
                table: "\"ShopLocation\"",
                column: "\"RoomId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"ShopLocation\"_\"ShopId\"",
                table: "\"ShopLocation\"",
                column: "\"ShopId\"");

            migrationBuilder.CreateIndex(
                name: "IX_\"Tenant\"_\"TenantTypeId\"",
                table: "\"Tenant\"",
                column: "\"TenantTypeId\"");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_\"RoleId\"",
                table: "AspNetRoleClaims",
                column: "\"RoleId\"");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "\"NormalizedName\"",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_\"UserId\"",
                table: "AspNetUserClaims",
                column: "\"UserId\"");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_\"UserId\"",
                table: "AspNetUserLogins",
                column: "\"UserId\"");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_\"RoleId\"",
                table: "AspNetUserRoles",
                column: "\"RoleId\"");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "\"NormalizedEmail\"");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_\"GenderId\"",
                table: "AspNetUsers",
                column: "\"GenderId\"");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "\"NormalizedUserName\"",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "\"Cart\"");

            migrationBuilder.DropTable(
                name: "\"ChapaWebhookResponse\"");

            migrationBuilder.DropTable(
                name: "\"ChatVersion\"");

            migrationBuilder.DropTable(
                name: "\"FloorPrice\"");

            migrationBuilder.DropTable(
                name: "\"Invoice\"");

            migrationBuilder.DropTable(
                name: "\"ItemImage\"");

            migrationBuilder.DropTable(
                name: "\"ItemPrice\"");

            migrationBuilder.DropTable(
                name: "\"MaintenanceRequest\"");

            migrationBuilder.DropTable(
                name: "\"Notification\"");

            migrationBuilder.DropTable(
                name: "\"OrderItem\"");

            migrationBuilder.DropTable(
                name: "\"RentalAgreementTermination\"");

            migrationBuilder.DropTable(
                name: "\"RoomPrice\"");

            migrationBuilder.DropTable(
                name: "\"RoomProperty\"");

            migrationBuilder.DropTable(
                name: "\"RoomPropertyTypeOption\"");

            migrationBuilder.DropTable(
                name: "\"RoomRentalPayment\"");

            migrationBuilder.DropTable(
                name: "\"ShopLocation\"");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "IdentityUserLogin<string>");

            migrationBuilder.DropTable(
                name: "IdentityUserToken<string>");

            migrationBuilder.DropTable(
                name: "\"Chat\"");

            migrationBuilder.DropTable(
                name: "\"InvoiceStatus\"");

            migrationBuilder.DropTable(
                name: "\"BuildingEmployee\"");

            migrationBuilder.DropTable(
                name: "\"MaintenanceStatus\"");

            migrationBuilder.DropTable(
                name: "\"MaintenanceType\"");

            migrationBuilder.DropTable(
                name: "\"NotificationStatus\"");

            migrationBuilder.DropTable(
                name: "\"NotificationType\"");

            migrationBuilder.DropTable(
                name: "\"Item\"");

            migrationBuilder.DropTable(
                name: "\"Order\"");

            migrationBuilder.DropTable(
                name: "\"RoomPropertyType\"");

            migrationBuilder.DropTable(
                name: "\"PaymentMode\"");

            migrationBuilder.DropTable(
                name: "\"PaymentType\"");

            migrationBuilder.DropTable(
                name: "\"RoomRental\"");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "\"ChatStatus\"");

            migrationBuilder.DropTable(
                name: "\"ServiceCategory\"");

            migrationBuilder.DropTable(
                name: "\"Shop\"");

            migrationBuilder.DropTable(
                name: "\"ItemCategory\"");

            migrationBuilder.DropTable(
                name: "\"Room\"");

            migrationBuilder.DropTable(
                name: "\"Tenant\"");

            migrationBuilder.DropTable(
                name: "\"BusinessArea\"");

            migrationBuilder.DropTable(
                name: "\"Floor\"");

            migrationBuilder.DropTable(
                name: "\"RoomStatue\"");

            migrationBuilder.DropTable(
                name: "\"TenantType\"");

            migrationBuilder.DropTable(
                name: "\"Building\"");

            migrationBuilder.DropTable(
                name: "\"BuildingType\"");

            migrationBuilder.DropTable(
                name: "\"Location\"");

            migrationBuilder.DropTable(
                name: "\"Owner\"");

            migrationBuilder.DropTable(
                name: "\"UseType\"");

            migrationBuilder.DropTable(
                name: "\"City\"");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "\"Documente\"");

            migrationBuilder.DropTable(
                name: "\"OwnershipType\"");

            migrationBuilder.DropTable(
                name: "\"Gender\"");
        }
    }
}
