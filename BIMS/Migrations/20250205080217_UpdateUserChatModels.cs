using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BIMS.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserChatModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "BuildingTypes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_BuildingTypes", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "BusinessAreas",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_BusinessAreas", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ChatStatuses",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ChatStatuses", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Cities",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Cities", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Documentes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Documentes", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Genders",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Genders", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "IdentityUserLogin<string>",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserLogin<string>", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserToken<string>",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserToken<string>", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            //migrationBuilder.CreateTable(
            //    name: "InvoiceStatuses",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_InvoiceStatuses", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ItemCategories",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ItemCategories", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "MaintenanceStatuses",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_MaintenanceStatuses", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "MaintenanceTypes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_MaintenanceTypes", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "NotificationStatuses",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_NotificationStatuses", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "NotificationTypes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_NotificationTypes", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "OwnershipTypes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_OwnershipTypes", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PaymentModes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PaymentModes", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PaymentTypes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PaymentTypes", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "RoomPropertyTypes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_RoomPropertyTypes", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "RoomStatues",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_RoomStatues", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ServiceCategories",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ServiceCategories", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TenantTypes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TenantTypes", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UseTypes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UseTypes", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateTable(
            //    name: "Locations",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Coordinates = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        CityId = table.Column<int>(type: "int", nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Locations", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Locations_Cities",
            //            column: x => x.CityId,
            //            principalTable: "Cities",
            //            principalColumn: "Id");
            //    });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                }
                //    table.ForeignKey(
                //        name: "FK_Users_Genders",
                //        column: x => x.GenderId,
                //        principalTable: "Genders",
                //        principalColumn: "Id");
                //}
        );

            //migrationBuilder.CreateTable(
            //    name: "Owners",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        OwnershipTypeId = table.Column<int>(type: "int", nullable: false),
            //        TIN = table.Column<int>(type: "int", nullable: false),
            //        DocumentId = table.Column<int>(type: "int", nullable: false),
            //        Verified = table.Column<bool>(type: "bit", nullable: false),
            //        RegisteredDate = table.Column<DateOnly>(type: "date", nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Owners", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Owners_Documentes",
            //            column: x => x.DocumentId,
            //            principalTable: "Documentes",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_Owners_OwnershipTypes",
            //            column: x => x.OwnershipTypeId,
            //            principalTable: "OwnershipTypes",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "RoomPropertyTypeOptions",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        RoomPropertyTypeId = table.Column<int>(type: "int", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_RoomPropertyTypeOptions", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_RoomPropertyTypeOptions_RoomPropertyTypes",
            //            column: x => x.RoomPropertyTypeId,
            //            principalTable: "RoomPropertyTypes",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Tenants",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Contact = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        TenantTypeId = table.Column<int>(type: "int", nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Tenants", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Tenants_TenantTypes",
            //            column: x => x.TenantTypeId,
            //            principalTable: "TenantTypes",
            //            principalColumn: "Id");
            //    });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateTable(
            //    name: "Chats",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        SenderId = table.Column<int>(type: "int", nullable: false),
            //        ReceiverId = table.Column<int>(type: "int", nullable: false),
            //        ParentId = table.Column<int>(type: "int", nullable: true),
            //        Message = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
            //        ChatStatusId = table.Column<int>(type: "int", nullable: false),
            //        Date = table.Column<DateOnly>(type: "date", nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Chats", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Chats_ChatStatuses",
            //            column: x => x.ChatStatusId,
            //            principalTable: "ChatStatuses",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_Chats_Chats",
            //            column: x => x.ParentId,
            //            principalTable: "Chats",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_Chats_Users",
            //            column: x => x.SenderId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_Chats_Users1",
            //            column: x => x.ReceiverId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Invoices",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<int>(type: "int", nullable: false),
            //        InvoiceStatusId = table.Column<int>(type: "int", nullable: false),
            //        Amount = table.Column<double>(type: "float", nullable: false),
            //        InvoiceDate = table.Column<DateOnly>(type: "date", nullable: false),
            //        DueDate = table.Column<DateOnly>(type: "date", nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Invoices", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Invoices_InvoiceStatuses",
            //            column: x => x.InvoiceStatusId,
            //            principalTable: "InvoiceStatuses",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_Invoices_Users",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Notifications",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<int>(type: "int", nullable: false),
            //        NotificationTypeId = table.Column<int>(type: "int", nullable: false),
            //        NotificationStatusId = table.Column<int>(type: "int", nullable: false),
            //        NotificationDate = table.Column<DateOnly>(type: "date", nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Notifications", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Notifications_NotificationStatuses",
            //            column: x => x.NotificationStatusId,
            //            principalTable: "NotificationStatuses",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_Notifications_NotificationTypes",
            //            column: x => x.NotificationTypeId,
            //            principalTable: "NotificationTypes",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_Notifications_Users",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Shops",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        UserId = table.Column<int>(type: "int", nullable: false),
            //        BusinessAreaId = table.Column<int>(type: "int", nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false),
            //        ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Shops", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Shops_BusinessAreas",
            //            column: x => x.BusinessAreaId,
            //            principalTable: "BusinessAreas",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_Shops_Users",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Buildings",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UseTypeId = table.Column<int>(type: "int", nullable: false),
            //        UserId = table.Column<int>(type: "int", nullable: false),
            //        CityId = table.Column<int>(type: "int", nullable: false),
            //        LocationId = table.Column<int>(type: "int", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
            //        ConstractionYear = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        NumberOfFloor = table.Column<int>(type: "int", nullable: false),
            //        BuildingTypeId = table.Column<int>(type: "int", nullable: false),
            //        OwnershipTypeId = table.Column<int>(type: "int", nullable: false),
            //        OwnerId = table.Column<int>(type: "int", nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Table_1", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Buildings_BuildingTypes",
            //            column: x => x.BuildingTypeId,
            //            principalTable: "BuildingTypes",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_Buildings_Cities",
            //            column: x => x.CityId,
            //            principalTable: "Cities",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_Buildings_Locations",
            //            column: x => x.LocationId,
            //            principalTable: "Locations",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_Buildings_Owners",
            //            column: x => x.OwnerId,
            //            principalTable: "Owners",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_Buildings_OwnershipTypes",
            //            column: x => x.OwnershipTypeId,
            //            principalTable: "OwnershipTypes",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_Buildings_UseTypes",
            //            column: x => x.UseTypeId,
            //            principalTable: "UseTypes",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_Buildings_Users",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ChatVersions",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ChatId = table.Column<int>(type: "int", nullable: false),
            //        Date = table.Column<DateOnly>(type: "date", nullable: false),
            //        OldMessage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ChatVersions", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_ChatVersions_Chats",
            //            column: x => x.ChatId,
            //            principalTable: "Chats",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Items",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        ItemCategoryId = table.Column<int>(type: "int", nullable: false),
            //        IsAvailable = table.Column<bool>(type: "bit", nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false),
            //        ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        ShopId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Items", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Items_ItemCategories",
            //            column: x => x.ItemCategoryId,
            //            principalTable: "ItemCategories",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_Items_Shops_ShopId",
            //            column: x => x.ShopId,
            //            principalTable: "Shops",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "BuildingEmployees",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        BuildingId = table.Column<int>(type: "int", nullable: false),
            //        UserId = table.Column<int>(type: "int", nullable: true),
            //        ServiceCategoryId = table.Column<int>(type: "int", nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_BuildingEmployees", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_BuildingEmployees_Buildings",
            //            column: x => x.BuildingId,
            //            principalTable: "Buildings",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_BuildingEmployees_ServiceCategories",
            //            column: x => x.ServiceCategoryId,
            //            principalTable: "ServiceCategories",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_BuildingEmployees_Users",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Floors",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        BuildingId = table.Column<int>(type: "int", nullable: false),
            //        NumberOfRoom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Floors", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Floors_Buildings",
            //            column: x => x.BuildingId,
            //            principalTable: "Buildings",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ItemImages",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ItemId = table.Column<int>(type: "int", nullable: false),
            //        Url = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ItemImages", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_ItemImages_Items",
            //            column: x => x.ItemId,
            //            principalTable: "Items",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ItemPrices",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ItemId = table.Column<int>(type: "int", nullable: false),
            //        AppliedDate = table.Column<DateOnly>(type: "date", nullable: true),
            //        MinPrice = table.Column<double>(type: "float", nullable: false),
            //        MaxPrice = table.Column<double>(type: "float", nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ItemPrices", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_ItemPrices_Items",
            //            column: x => x.ItemId,
            //            principalTable: "Items",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "FloorPrices",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FloorId = table.Column<int>(type: "int", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Price = table.Column<double>(type: "float", nullable: false),
            //        AppliedDate = table.Column<DateOnly>(type: "date", nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_FloorPrices", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_FloorPrices_Floors",
            //            column: x => x.FloorId,
            //            principalTable: "Floors",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Rooms",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        FloorId = table.Column<int>(type: "int", nullable: false),
            //        UserId = table.Column<int>(type: "int", nullable: false),
            //        RoomStatusId = table.Column<int>(type: "int", nullable: false),
            //        SizeInm2 = table.Column<int>(type: "int", nullable: false),
            //        Width = table.Column<double>(type: "float", nullable: false),
            //        Length = table.Column<double>(type: "float", nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Rooms", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Rooms_Floors",
            //            column: x => x.FloorId,
            //            principalTable: "Floors",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_Rooms_RoomStatues",
            //            column: x => x.RoomStatusId,
            //            principalTable: "RoomStatues",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_Rooms_Users",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "MaintenanceRequests",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<int>(type: "int", nullable: false),
            //        RoomId = table.Column<int>(type: "int", nullable: false),
            //        MaintenanceTypeId = table.Column<int>(type: "int", nullable: false),
            //        BuildingEmployeeId = table.Column<int>(type: "int", nullable: false),
            //        MaintenanceStatusId = table.Column<int>(type: "int", nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
            //        DateSubmitted = table.Column<DateOnly>(type: "date", nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_MaintenanceRequests", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_MaintenanceRequests_BuildingEmployees",
            //            column: x => x.BuildingEmployeeId,
            //            principalTable: "BuildingEmployees",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_MaintenanceRequests_MaintenanceStatuses",
            //            column: x => x.MaintenanceStatusId,
            //            principalTable: "MaintenanceStatuses",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_MaintenanceRequests_MaintenanceTypes",
            //            column: x => x.MaintenanceTypeId,
            //            principalTable: "MaintenanceTypes",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_MaintenanceRequests_Rooms",
            //            column: x => x.RoomId,
            //            principalTable: "Rooms",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_MaintenanceRequests_Users",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "RoomPrices",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        RoomId = table.Column<int>(type: "int", nullable: false),
            //        PricePerM2 = table.Column<double>(type: "float", nullable: false),
            //        AppliedDate = table.Column<DateOnly>(type: "date", nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_RoomPrices", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_RoomPrices_Rooms",
            //            column: x => x.RoomId,
            //            principalTable: "Rooms",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "RoomProperties",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        RoomId = table.Column<int>(type: "int", nullable: false),
            //        RoomPropertyTypeId = table.Column<int>(type: "int", nullable: false),
            //        Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_RoomProperties", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_RoomProperties_RoomPropertyTypes",
            //            column: x => x.RoomPropertyTypeId,
            //            principalTable: "RoomPropertyTypes",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_RoomProperties_Rooms",
            //            column: x => x.RoomId,
            //            principalTable: "Rooms",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "RoomRentals",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        RoomId = table.Column<int>(type: "int", nullable: false),
            //        TenantId = table.Column<int>(type: "int", nullable: false),
            //        TotalPrice = table.Column<double>(type: "float", nullable: false),
            //        StartDate = table.Column<DateOnly>(type: "date", nullable: false),
            //        BusinessAreaId = table.Column<int>(type: "int", nullable: false),
            //        DocumentId = table.Column<int>(type: "int", nullable: true),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_RoomRentals", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_RoomRentals_BusinessAreas",
            //            column: x => x.BusinessAreaId,
            //            principalTable: "BusinessAreas",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_RoomRentals_Documentes",
            //            column: x => x.DocumentId,
            //            principalTable: "Documentes",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_RoomRentals_Rooms",
            //            column: x => x.RoomId,
            //            principalTable: "Rooms",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_RoomRentals_Tenants",
            //            column: x => x.TenantId,
            //            principalTable: "Tenants",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ShopLocations",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        RoomId = table.Column<int>(type: "int", nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false),
            //        ShopId = table.Column<int>(type: "int", nullable: false),
            //        CreatedDate = table.Column<DateOnly>(type: "date", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ShopLocations", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_ShopLocations_Rooms",
            //            column: x => x.RoomId,
            //            principalTable: "Rooms",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_ShopLocations_Shops",
            //            column: x => x.ShopId,
            //            principalTable: "Shops",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "RentalAgreementTerminations",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        RoomRentalId = table.Column<int>(type: "int", nullable: false),
            //        Reason = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        DocumentId = table.Column<int>(type: "int", nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_RentalAgreementTerminations", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_RentalAgreementTerminations_Documentes",
            //            column: x => x.DocumentId,
            //            principalTable: "Documentes",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_RentalAgreementTerminations_RoomRentals",
            //            column: x => x.RoomRentalId,
            //            principalTable: "RoomRentals",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "RoomRentalPayments",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        RoomRentalId = table.Column<int>(type: "int", nullable: false),
            //        PaymentTypeId = table.Column<int>(type: "int", nullable: false),
            //        PaymentModeId = table.Column<int>(type: "int", nullable: false),
            //        PaidDate = table.Column<DateOnly>(type: "date", nullable: false),
            //        TotalAmount = table.Column<double>(type: "float", nullable: false),
            //        InvoiceNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_RoomRentalPayments", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_RoomRentalPayments_PaymentModes",
            //            column: x => x.PaymentModeId,
            //            principalTable: "PaymentModes",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_RoomRentalPayments_PaymentTypes",
            //            column: x => x.PaymentTypeId,
            //            principalTable: "PaymentTypes",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_RoomRentalPayments_RoomRentals",
            //            column: x => x.RoomRentalId,
            //            principalTable: "RoomRentals",
            //            principalColumn: "Id");
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GenderId",
                table: "AspNetUsers",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingEmployees_BuildingId",
                table: "BuildingEmployees",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingEmployees_ServiceCategoryId",
                table: "BuildingEmployees",
                column: "ServiceCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingEmployees_UserId",
                table: "BuildingEmployees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_BuildingTypeId",
                table: "Buildings",
                column: "BuildingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_CityId",
                table: "Buildings",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_LocationId",
                table: "Buildings",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_OwnerId",
                table: "Buildings",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_OwnershipTypeId",
                table: "Buildings",
                column: "OwnershipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_UserId",
                table: "Buildings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_UseTypeId",
                table: "Buildings",
                column: "UseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_ChatStatusId",
                table: "Chats",
                column: "ChatStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_ParentId",
                table: "Chats",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_ReceiverId",
                table: "Chats",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_SenderId",
                table: "Chats",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatVersions_ChatId",
                table: "ChatVersions",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_FloorPrices_FloorId",
                table: "FloorPrices",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_Floors_BuildingId",
                table: "Floors",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_InvoiceStatusId",
                table: "Invoices",
                column: "InvoiceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_UserId",
                table: "Invoices",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemImages_ItemId",
                table: "ItemImages",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPrices_ItemId",
                table: "ItemPrices",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemCategoryId",
                table: "Items",
                column: "ItemCategoryId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Items_ShopId",
            //    table: "Items",
            //    column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CityId",
                table: "Locations",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_BuildingEmployeeId",
                table: "MaintenanceRequests",
                column: "BuildingEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_MaintenanceStatusId",
                table: "MaintenanceRequests",
                column: "MaintenanceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_MaintenanceTypeId",
                table: "MaintenanceRequests",
                column: "MaintenanceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_RoomId",
                table: "MaintenanceRequests",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_UserId",
                table: "MaintenanceRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_NotificationStatusId",
                table: "Notifications",
                column: "NotificationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_NotificationTypeId",
                table: "Notifications",
                column: "NotificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_DocumentId",
                table: "Owners",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_OwnershipTypeId",
                table: "Owners",
                column: "OwnershipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalAgreementTerminations_DocumentId",
                table: "RentalAgreementTerminations",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalAgreementTerminations_RoomRentalId",
                table: "RentalAgreementTerminations",
                column: "RoomRentalId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomPrices_RoomId",
                table: "RoomPrices",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomProperties_RoomId",
                table: "RoomProperties",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomProperties_RoomPropertyTypeId",
                table: "RoomProperties",
                column: "RoomPropertyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomPropertyTypeOptions_RoomPropertyTypeId",
                table: "RoomPropertyTypeOptions",
                column: "RoomPropertyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomRentalPayments_PaymentModeId",
                table: "RoomRentalPayments",
                column: "PaymentModeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomRentalPayments_PaymentTypeId",
                table: "RoomRentalPayments",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomRentalPayments_RoomRentalId",
                table: "RoomRentalPayments",
                column: "RoomRentalId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomRentals_BusinessAreaId",
                table: "RoomRentals",
                column: "BusinessAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomRentals_DocumentId",
                table: "RoomRentals",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomRentals_RoomId",
                table: "RoomRentals",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomRentals_TenantId",
                table: "RoomRentals",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_FloorId",
                table: "Rooms",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomStatusId",
                table: "Rooms",
                column: "RoomStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_UserId",
                table: "Rooms",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopLocations_RoomId",
                table: "ShopLocations",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopLocations_ShopId",
                table: "ShopLocations",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_BusinessAreaId",
                table: "Shops",
                column: "BusinessAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_UserId",
                table: "Shops",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_TenantTypeId",
                table: "Tenants",
                column: "TenantTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            //migrationBuilder.DropTable(
            //    name: "ChatVersions");

            //migrationBuilder.DropTable(
            //    name: "FloorPrices");

            migrationBuilder.DropTable(
                name: "IdentityUserLogin<string>");

            migrationBuilder.DropTable(
                name: "IdentityUserToken<string>");

            //migrationBuilder.DropTable(
            //    name: "Invoices");

            //migrationBuilder.DropTable(
            //    name: "ItemImages");

            //migrationBuilder.DropTable(
            //    name: "ItemPrices");

            //migrationBuilder.DropTable(
            //    name: "MaintenanceRequests");

            //migrationBuilder.DropTable(
            //    name: "Notifications");

            //migrationBuilder.DropTable(
            //   name: "RentalAgreementTerminations");

            //migrationBuilder.DropTable(
            //    name: "RoomPrices");

            //migrationBuilder.DropTable(
            //    name: "RoomProperties");

            //migrationBuilder.DropTable(
            //    name: "RoomPropertyTypeOptions");

            //migrationBuilder.DropTable(
            //    name: "RoomRentalPayments");

            //migrationBuilder.DropTable(
            //    name: "ShopLocations");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            //migrationBuilder.DropTable(
            //    name: "Chats");

            //migrationBuilder.DropTable(
            //    name: "InvoiceStatuses");

            //migrationBuilder.DropTable(
            //    name: "Items");

            //migrationBuilder.DropTable(
            //    name: "BuildingEmployees");

            //migrationBuilder.DropTable(
            //    name: "MaintenanceStatuses");

            //migrationBuilder.DropTable(
            //    name: "MaintenanceTypes");

            //migrationBuilder.DropTable(
            //    name: "NotificationStatuses");

            //migrationBuilder.DropTable(
            //    name: "NotificationTypes");

            //migrationBuilder.DropTable(
            //    name: "RoomPropertyTypes");

            //migrationBuilder.DropTable(
            //    name: "PaymentModes");

            //migrationBuilder.DropTable(
            //    name: "PaymentTypes");

            //migrationBuilder.DropTable(
            //    name: "RoomRentals");

            //migrationBuilder.DropTable(
            //    name: "ChatStatuses");

            //migrationBuilder.DropTable(
            //    name: "ItemCategories");

            //migrationBuilder.DropTable(
            //    name: "Shops");

            //migrationBuilder.DropTable(
            //    name: "ServiceCategories");

            //migrationBuilder.DropTable(
            //    name: "Rooms");

            //migrationBuilder.DropTable(
            //    name: "Tenants");

            //migrationBuilder.DropTable(
            //    name: "BusinessAreas");

            //migrationBuilder.DropTable(
            //    name: "Floors");

            //migrationBuilder.DropTable(
            //    name: "RoomStatues");

            //migrationBuilder.DropTable(
            //    name: "TenantTypes");

            //migrationBuilder.DropTable(
            //    name: "Buildings");

            //migrationBuilder.DropTable(
            //    name: "BuildingTypes");

            //migrationBuilder.DropTable(
            //    name: "Locations");

            //migrationBuilder.DropTable(
            //    name: "Owners");

            //migrationBuilder.DropTable(
            //    name: "UseTypes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            //migrationBuilder.DropTable(
            //    name: "Cities");

            //migrationBuilder.DropTable(
            //    name: "Documentes");

            //migrationBuilder.DropTable(
            //    name: "OwnershipTypes");

            //migrationBuilder.DropTable(
            //    name: "Genders");
        }
    }
}
