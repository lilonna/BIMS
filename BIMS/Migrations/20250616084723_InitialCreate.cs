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
                name: "AspNetRoles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalizedname = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    concurrencystamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "buildingtypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_buildingtypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "businessareas",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_businessareas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "chapawebhookresponses",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    txref = table.Column<string>(type: "text", nullable: true),
                    amount = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_chapawebhookresponses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "chatstatuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_chatstatuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documentes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_documentes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "genders",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_genders", x => x.id);
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
                name: "invoicestatuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_invoicestatuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "itemcategories",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_itemcategories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "maintenancestatuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_maintenancestatuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "maintenancetypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_maintenancetypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "notificationstatuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_notificationstatuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "notificationtypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_notificationtypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ownershiptypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ownershiptypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "paymentmodes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_paymentmodes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "paymenttypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_paymenttypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roompropertytypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roompropertytypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roomstatues",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roomstatues", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "servicecategories",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_servicecategories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tenanttypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tenanttypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usetypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_usetypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    roleid = table.Column<int>(type: "integer", nullable: false),
                    claimtype = table.Column<string>(type: "text", nullable: true),
                    claimvalue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roleclaims", x => x.id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_roleid",
                        column: x => x.roleid,
                        principalTable: "AspNetRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    coordinates = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    cityid = table.Column<int>(type: "integer", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_locations", x => x.id);
                    table.ForeignKey(
                        name: "FK_Locations_Cities",
                        column: x => x.cityid,
                        principalTable: "cities",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    ownerid = table.Column<int>(type: "integer", nullable: true),
                    genderid = table.Column<int>(type: "integer", nullable: false),
                    firstname = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    middlename = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    lastname = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    phonenumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    createddate = table.Column<DateOnly>(type: "date", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false),
                    password = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    username = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalizedusername = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalizedemail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    emailconfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    passwordhash = table.Column<string>(type: "text", nullable: true),
                    securitystamp = table.Column<string>(type: "text", nullable: true),
                    concurrencystamp = table.Column<string>(type: "text", nullable: true),
                    phonenumberconfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    twofactorenabled = table.Column<bool>(type: "boolean", nullable: false),
                    lockoutend = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    lockoutenabled = table.Column<bool>(type: "boolean", nullable: false),
                    accessfailedcount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user", x => x.id);
                    table.ForeignKey(
                        name: "FK_Users_Genders",
                        column: x => x.genderid,
                        principalTable: "genders",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "roompropertytypeoptions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    roompropertytypeid = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roompropertytypeoptions", x => x.id);
                    table.ForeignKey(
                        name: "FK_RoomPropertyTypeOptions_RoomPropertyTypes",
                        column: x => x.roompropertytypeid,
                        principalTable: "roompropertytypes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "tenants",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    contact = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    tenanttypeid = table.Column<int>(type: "integer", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tenants", x => x.id);
                    table.ForeignKey(
                        name: "FK_Tenants_TenantTypes",
                        column: x => x.tenanttypeid,
                        principalTable: "tenanttypes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<int>(type: "integer", nullable: false),
                    claimtype = table.Column<string>(type: "text", nullable: true),
                    claimvalue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_userclaims", x => x.id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_userid",
                        column: x => x.userid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    loginprovider = table.Column<string>(type: "text", nullable: false),
                    providerkey = table.Column<string>(type: "text", nullable: false),
                    providerdisplayname = table.Column<string>(type: "text", nullable: true),
                    userid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.loginprovider, x.providerkey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_userid",
                        column: x => x.userid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    userid = table.Column<int>(type: "integer", nullable: false),
                    roleid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.userid, x.roleid });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_roleid",
                        column: x => x.roleid,
                        principalTable: "AspNetRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_userid",
                        column: x => x.userid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    userid = table.Column<int>(type: "integer", nullable: false),
                    loginprovider = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.userid, x.loginprovider, x.name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_userid",
                        column: x => x.userid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chats",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    senderid = table.Column<int>(type: "integer", nullable: false),
                    receiverid = table.Column<int>(type: "integer", nullable: false),
                    parentid = table.Column<int>(type: "integer", nullable: true),
                    message = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    chatstatusid = table.Column<int>(type: "integer", nullable: false),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_chats", x => x.id);
                    table.ForeignKey(
                        name: "FK_Chats_ChatStatuses",
                        column: x => x.chatstatusid,
                        principalTable: "chatstatuses",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Chats_Chats",
                        column: x => x.parentid,
                        principalTable: "chats",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Chats_Users",
                        column: x => x.senderid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Chats_Users1",
                        column: x => x.receiverid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "invoices",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<int>(type: "integer", nullable: false),
                    invoicestatusid = table.Column<int>(type: "integer", nullable: false),
                    amount = table.Column<double>(type: "double precision", nullable: false),
                    invoicedate = table.Column<DateOnly>(type: "date", nullable: false),
                    duedate = table.Column<DateOnly>(type: "date", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_invoices", x => x.id);
                    table.ForeignKey(
                        name: "FK_Invoices_InvoiceStatuses",
                        column: x => x.invoicestatusid,
                        principalTable: "invoicestatuses",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Invoices_Users",
                        column: x => x.userid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "notifications",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    message = table.Column<string>(type: "text", nullable: true),
                    tempcolumn = table.Column<bool>(type: "boolean", nullable: false),
                    userid = table.Column<int>(type: "integer", nullable: false),
                    notificationtypeid = table.Column<int>(type: "integer", nullable: false),
                    notificationstatusid = table.Column<int>(type: "integer", nullable: false),
                    notificationdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    isread = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_notifications", x => x.id);
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers",
                        column: x => x.userid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Notifications_NotificationStatuses",
                        column: x => x.notificationstatusid,
                        principalTable: "notificationstatuses",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Notifications_NotificationTypes",
                        column: x => x.notificationtypeid,
                        principalTable: "notificationtypes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<int>(type: "integer", nullable: false),
                    orderdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    totalamount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    shippingaddress = table.Column<string>(type: "text", nullable: true),
                    transactionref = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<string>(type: "text", nullable: true),
                    paymentstatus = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orders", x => x.id);
                    table.ForeignKey(
                        name: "fk_orders_user_userid",
                        column: x => x.userid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "owners",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<int>(type: "integer", nullable: false),
                    fullname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ownershiptypeid = table.Column<int>(type: "integer", nullable: false),
                    tin = table.Column<int>(type: "integer", nullable: false),
                    documentid = table.Column<int>(type: "integer", nullable: true),
                    verified = table.Column<bool>(type: "boolean", nullable: false),
                    bankname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    registereddate = table.Column<DateOnly>(type: "date", nullable: false),
                    license = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    bankaccountnumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_owners", x => x.id);
                    table.ForeignKey(
                        name: "FK_Owners_Documentes",
                        column: x => x.documentid,
                        principalTable: "documentes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Owners_OwnershipTypes",
                        column: x => x.ownershiptypeid,
                        principalTable: "ownershiptypes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_owners_user_userid",
                        column: x => x.userid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shops",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    userid = table.Column<int>(type: "integer", nullable: false),
                    businessareaid = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false),
                    imageurl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_shops", x => x.id);
                    table.ForeignKey(
                        name: "FK_Shops_BusinessAreas",
                        column: x => x.businessareaid,
                        principalTable: "businessareas",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Shops_Users",
                        column: x => x.userid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "chatversions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    chatid = table.Column<int>(type: "integer", nullable: false),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    oldmessage = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_chatversions", x => x.id);
                    table.ForeignKey(
                        name: "FK_ChatVersions_Chats",
                        column: x => x.chatid,
                        principalTable: "chats",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "buildings",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    usetypeid = table.Column<int>(type: "integer", nullable: false),
                    userid = table.Column<int>(type: "integer", nullable: false),
                    cityid = table.Column<int>(type: "integer", nullable: false),
                    locationid = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    constractionyear = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    numberoffloor = table.Column<int>(type: "integer", nullable: false),
                    buildingtypeid = table.Column<int>(type: "integer", nullable: false),
                    ownershiptypeid = table.Column<int>(type: "integer", nullable: false),
                    ownerid = table.Column<int>(type: "integer", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1", x => x.id);
                    table.ForeignKey(
                        name: "FK_Buildings_BuildingTypes",
                        column: x => x.buildingtypeid,
                        principalTable: "buildingtypes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Buildings_Cities",
                        column: x => x.cityid,
                        principalTable: "cities",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Buildings_Locations",
                        column: x => x.locationid,
                        principalTable: "locations",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Buildings_Owners",
                        column: x => x.ownerid,
                        principalTable: "owners",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Buildings_OwnershipTypes",
                        column: x => x.ownershiptypeid,
                        principalTable: "ownershiptypes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Buildings_UseTypes",
                        column: x => x.usetypeid,
                        principalTable: "usetypes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Buildings_Users",
                        column: x => x.userid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    itemcategoryid = table.Column<int>(type: "integer", nullable: false),
                    isavailable = table.Column<bool>(type: "boolean", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false),
                    stock = table.Column<int>(type: "integer", nullable: false),
                    discountprice = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    salescount = table.Column<int>(type: "integer", nullable: false),
                    imagepath = table.Column<string>(type: "text", nullable: true),
                    price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    shopid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_items", x => x.id);
                    table.ForeignKey(
                        name: "FK_Items_ItemCategories",
                        column: x => x.itemcategoryid,
                        principalTable: "itemcategories",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_items_shops_shopid",
                        column: x => x.shopid,
                        principalTable: "shops",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "buildingemployees",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fullname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    phonenumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    buildingid = table.Column<int>(type: "integer", nullable: false),
                    userid = table.Column<int>(type: "integer", nullable: true),
                    servicecategoryid = table.Column<int>(type: "integer", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_buildingemployees", x => x.id);
                    table.ForeignKey(
                        name: "FK_BuildingEmployees_Buildings",
                        column: x => x.buildingid,
                        principalTable: "buildings",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_BuildingEmployees_ServiceCategories",
                        column: x => x.servicecategoryid,
                        principalTable: "servicecategories",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_BuildingEmployees_Users",
                        column: x => x.userid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "floors",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    buildingid = table.Column<int>(type: "integer", nullable: false),
                    numberofroom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_floors", x => x.id);
                    table.ForeignKey(
                        name: "FK_Floors_Buildings",
                        column: x => x.buildingid,
                        principalTable: "buildings",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "carts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<int>(type: "integer", nullable: false),
                    itemid = table.Column<int>(type: "integer", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    totalprice = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_carts", x => x.id);
                    table.ForeignKey(
                        name: "fk_carts_items_itemid",
                        column: x => x.itemid,
                        principalTable: "items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_carts_user_userid",
                        column: x => x.userid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "itemimages",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    itemid = table.Column<int>(type: "integer", nullable: false),
                    url = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_itemimages", x => x.id);
                    table.ForeignKey(
                        name: "FK_ItemImages_Items",
                        column: x => x.itemid,
                        principalTable: "items",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "itemprices",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    itemid = table.Column<int>(type: "integer", nullable: false),
                    applieddate = table.Column<DateOnly>(type: "date", nullable: true),
                    minprice = table.Column<double>(type: "double precision", nullable: false),
                    maxprice = table.Column<double>(type: "double precision", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_itemprices", x => x.id);
                    table.ForeignKey(
                        name: "FK_ItemPrices_Items",
                        column: x => x.itemid,
                        principalTable: "items",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "orderitems",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    orderid = table.Column<int>(type: "integer", nullable: false),
                    itemid = table.Column<int>(type: "integer", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orderitems", x => x.id);
                    table.ForeignKey(
                        name: "fk_orderitems_items_itemid",
                        column: x => x.itemid,
                        principalTable: "items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_orderitems_orders_orderid",
                        column: x => x.orderid,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "floorprices",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    floorid = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    applieddate = table.Column<DateOnly>(type: "date", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_floorprices", x => x.id);
                    table.ForeignKey(
                        name: "FK_FloorPrices_Floors",
                        column: x => x.floorid,
                        principalTable: "floors",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "rooms",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    floorid = table.Column<int>(type: "integer", nullable: false),
                    userid = table.Column<int>(type: "integer", nullable: false),
                    roomstatusid = table.Column<int>(type: "integer", nullable: false),
                    sizeinm2 = table.Column<int>(type: "integer", nullable: false),
                    width = table.Column<double>(type: "double precision", nullable: false),
                    length = table.Column<double>(type: "double precision", nullable: false),
                    description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_rooms", x => x.id);
                    table.ForeignKey(
                        name: "FK_Rooms_Floors",
                        column: x => x.floorid,
                        principalTable: "floors",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Rooms_RoomStatues",
                        column: x => x.roomstatusid,
                        principalTable: "roomstatues",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Rooms_Users",
                        column: x => x.userid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "maintenancerequests",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<int>(type: "integer", nullable: false),
                    roomid = table.Column<int>(type: "integer", nullable: false),
                    maintenancetypeid = table.Column<int>(type: "integer", nullable: false),
                    buildingemployeeid = table.Column<int>(type: "integer", nullable: false),
                    maintenancestatusid = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    datesubmitted = table.Column<DateOnly>(type: "date", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_maintenancerequests", x => x.id);
                    table.ForeignKey(
                        name: "FK_MaintenanceRequests_BuildingEmployees",
                        column: x => x.buildingemployeeid,
                        principalTable: "buildingemployees",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_MaintenanceRequests_MaintenanceStatuses",
                        column: x => x.maintenancestatusid,
                        principalTable: "maintenancestatuses",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_MaintenanceRequests_MaintenanceTypes",
                        column: x => x.maintenancetypeid,
                        principalTable: "maintenancetypes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_MaintenanceRequests_Rooms",
                        column: x => x.roomid,
                        principalTable: "rooms",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_MaintenanceRequests_Users",
                        column: x => x.userid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "roomprices",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    roomid = table.Column<int>(type: "integer", nullable: false),
                    priceperm2 = table.Column<double>(type: "double precision", nullable: false),
                    applieddate = table.Column<DateOnly>(type: "date", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roomprices", x => x.id);
                    table.ForeignKey(
                        name: "FK_RoomPrices_Rooms",
                        column: x => x.roomid,
                        principalTable: "rooms",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "roomproperties",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    roomid = table.Column<int>(type: "integer", nullable: false),
                    roompropertytypeid = table.Column<int>(type: "integer", nullable: false),
                    value = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roomproperties", x => x.id);
                    table.ForeignKey(
                        name: "FK_RoomProperties_RoomPropertyTypes",
                        column: x => x.roompropertytypeid,
                        principalTable: "roompropertytypes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_RoomProperties_Rooms",
                        column: x => x.roomid,
                        principalTable: "rooms",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "roomrentals",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    roomid = table.Column<int>(type: "integer", nullable: false),
                    tenantid = table.Column<int>(type: "integer", nullable: false),
                    totalprice = table.Column<double>(type: "double precision", nullable: false),
                    startdate = table.Column<DateOnly>(type: "date", nullable: false),
                    businessareaid = table.Column<int>(type: "integer", nullable: false),
                    documentid = table.Column<int>(type: "integer", nullable: true),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roomrentals", x => x.id);
                    table.ForeignKey(
                        name: "FK_RoomRentals_BusinessAreas",
                        column: x => x.businessareaid,
                        principalTable: "businessareas",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_RoomRentals_Documentes",
                        column: x => x.documentid,
                        principalTable: "documentes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_RoomRentals_Rooms",
                        column: x => x.roomid,
                        principalTable: "rooms",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_RoomRentals_Tenants",
                        column: x => x.tenantid,
                        principalTable: "tenants",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "shoplocations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    roomid = table.Column<int>(type: "integer", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false),
                    shopid = table.Column<int>(type: "integer", nullable: false),
                    createddate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_shoplocations", x => x.id);
                    table.ForeignKey(
                        name: "FK_ShopLocations_Rooms",
                        column: x => x.roomid,
                        principalTable: "rooms",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ShopLocations_Shops",
                        column: x => x.shopid,
                        principalTable: "shops",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "rentalagreementterminations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    roomrentalid = table.Column<int>(type: "integer", nullable: false),
                    reason = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    documentid = table.Column<int>(type: "integer", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_rentalagreementterminations", x => x.id);
                    table.ForeignKey(
                        name: "FK_RentalAgreementTerminations_Documentes",
                        column: x => x.documentid,
                        principalTable: "documentes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_RentalAgreementTerminations_RoomRentals",
                        column: x => x.roomrentalid,
                        principalTable: "roomrentals",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "roomrentalpayments",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    roomrentalid = table.Column<int>(type: "integer", nullable: false),
                    paymenttypeid = table.Column<int>(type: "integer", nullable: false),
                    paymentmodeid = table.Column<int>(type: "integer", nullable: false),
                    paiddate = table.Column<DateOnly>(type: "date", nullable: false),
                    totalamount = table.Column<double>(type: "double precision", nullable: false),
                    invoicenumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roomrentalpayments", x => x.id);
                    table.ForeignKey(
                        name: "FK_RoomRentalPayments_PaymentModes",
                        column: x => x.paymentmodeid,
                        principalTable: "paymentmodes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_RoomRentalPayments_PaymentTypes",
                        column: x => x.paymenttypeid,
                        principalTable: "paymenttypes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_RoomRentalPayments_RoomRentals",
                        column: x => x.roomrentalid,
                        principalTable: "roomrentals",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_roleid",
                table: "AspNetRoleClaims",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "normalizedname",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_userid",
                table: "AspNetUserClaims",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_userid",
                table: "AspNetUserLogins",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_roleid",
                table: "AspNetUserRoles",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "normalizedemail");

            migrationBuilder.CreateIndex(
                name: "ix_user_genderid",
                table: "AspNetUsers",
                column: "genderid");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "normalizedusername",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_buildingemployees_buildingid",
                table: "buildingemployees",
                column: "buildingid");

            migrationBuilder.CreateIndex(
                name: "ix_buildingemployees_servicecategoryid",
                table: "buildingemployees",
                column: "servicecategoryid");

            migrationBuilder.CreateIndex(
                name: "ix_buildingemployees_userid",
                table: "buildingemployees",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "ix_buildings_buildingtypeid",
                table: "buildings",
                column: "buildingtypeid");

            migrationBuilder.CreateIndex(
                name: "ix_buildings_cityid",
                table: "buildings",
                column: "cityid");

            migrationBuilder.CreateIndex(
                name: "ix_buildings_locationid",
                table: "buildings",
                column: "locationid");

            migrationBuilder.CreateIndex(
                name: "ix_buildings_ownerid",
                table: "buildings",
                column: "ownerid");

            migrationBuilder.CreateIndex(
                name: "ix_buildings_ownershiptypeid",
                table: "buildings",
                column: "ownershiptypeid");

            migrationBuilder.CreateIndex(
                name: "ix_buildings_userid",
                table: "buildings",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "ix_buildings_usetypeid",
                table: "buildings",
                column: "usetypeid");

            migrationBuilder.CreateIndex(
                name: "ix_carts_itemid",
                table: "carts",
                column: "itemid");

            migrationBuilder.CreateIndex(
                name: "ix_carts_userid",
                table: "carts",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "ix_chats_chatstatusid",
                table: "chats",
                column: "chatstatusid");

            migrationBuilder.CreateIndex(
                name: "ix_chats_parentid",
                table: "chats",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "ix_chats_receiverid",
                table: "chats",
                column: "receiverid");

            migrationBuilder.CreateIndex(
                name: "ix_chats_senderid",
                table: "chats",
                column: "senderid");

            migrationBuilder.CreateIndex(
                name: "ix_chatversions_chatid",
                table: "chatversions",
                column: "chatid");

            migrationBuilder.CreateIndex(
                name: "ix_floorprices_floorid",
                table: "floorprices",
                column: "floorid");

            migrationBuilder.CreateIndex(
                name: "ix_floors_buildingid",
                table: "floors",
                column: "buildingid");

            migrationBuilder.CreateIndex(
                name: "ix_invoices_invoicestatusid",
                table: "invoices",
                column: "invoicestatusid");

            migrationBuilder.CreateIndex(
                name: "ix_invoices_userid",
                table: "invoices",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "ix_itemimages_itemid",
                table: "itemimages",
                column: "itemid");

            migrationBuilder.CreateIndex(
                name: "ix_itemprices_itemid",
                table: "itemprices",
                column: "itemid");

            migrationBuilder.CreateIndex(
                name: "ix_items_itemcategoryid",
                table: "items",
                column: "itemcategoryid");

            migrationBuilder.CreateIndex(
                name: "ix_items_shopid",
                table: "items",
                column: "shopid");

            migrationBuilder.CreateIndex(
                name: "ix_locations_cityid",
                table: "locations",
                column: "cityid");

            migrationBuilder.CreateIndex(
                name: "ix_maintenancerequests_buildingemployeeid",
                table: "maintenancerequests",
                column: "buildingemployeeid");

            migrationBuilder.CreateIndex(
                name: "ix_maintenancerequests_maintenancestatusid",
                table: "maintenancerequests",
                column: "maintenancestatusid");

            migrationBuilder.CreateIndex(
                name: "ix_maintenancerequests_maintenancetypeid",
                table: "maintenancerequests",
                column: "maintenancetypeid");

            migrationBuilder.CreateIndex(
                name: "ix_maintenancerequests_roomid",
                table: "maintenancerequests",
                column: "roomid");

            migrationBuilder.CreateIndex(
                name: "ix_maintenancerequests_userid",
                table: "maintenancerequests",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "ix_notifications_notificationstatusid",
                table: "notifications",
                column: "notificationstatusid");

            migrationBuilder.CreateIndex(
                name: "ix_notifications_notificationtypeid",
                table: "notifications",
                column: "notificationtypeid");

            migrationBuilder.CreateIndex(
                name: "ix_notifications_userid",
                table: "notifications",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "ix_orderitems_itemid",
                table: "orderitems",
                column: "itemid");

            migrationBuilder.CreateIndex(
                name: "ix_orderitems_orderid",
                table: "orderitems",
                column: "orderid");

            migrationBuilder.CreateIndex(
                name: "ix_orders_userid",
                table: "orders",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "ix_owners_documentid",
                table: "owners",
                column: "documentid");

            migrationBuilder.CreateIndex(
                name: "ix_owners_ownershiptypeid",
                table: "owners",
                column: "ownershiptypeid");

            migrationBuilder.CreateIndex(
                name: "ix_owners_userid",
                table: "owners",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "ix_rentalagreementterminations_documentid",
                table: "rentalagreementterminations",
                column: "documentid");

            migrationBuilder.CreateIndex(
                name: "ix_rentalagreementterminations_roomrentalid",
                table: "rentalagreementterminations",
                column: "roomrentalid");

            migrationBuilder.CreateIndex(
                name: "ix_roomprices_roomid",
                table: "roomprices",
                column: "roomid");

            migrationBuilder.CreateIndex(
                name: "ix_roomproperties_roomid",
                table: "roomproperties",
                column: "roomid");

            migrationBuilder.CreateIndex(
                name: "ix_roomproperties_roompropertytypeid",
                table: "roomproperties",
                column: "roompropertytypeid");

            migrationBuilder.CreateIndex(
                name: "ix_roompropertytypeoptions_roompropertytypeid",
                table: "roompropertytypeoptions",
                column: "roompropertytypeid");

            migrationBuilder.CreateIndex(
                name: "ix_roomrentalpayments_paymentmodeid",
                table: "roomrentalpayments",
                column: "paymentmodeid");

            migrationBuilder.CreateIndex(
                name: "ix_roomrentalpayments_paymenttypeid",
                table: "roomrentalpayments",
                column: "paymenttypeid");

            migrationBuilder.CreateIndex(
                name: "ix_roomrentalpayments_roomrentalid",
                table: "roomrentalpayments",
                column: "roomrentalid");

            migrationBuilder.CreateIndex(
                name: "ix_roomrentals_businessareaid",
                table: "roomrentals",
                column: "businessareaid");

            migrationBuilder.CreateIndex(
                name: "ix_roomrentals_documentid",
                table: "roomrentals",
                column: "documentid");

            migrationBuilder.CreateIndex(
                name: "ix_roomrentals_roomid",
                table: "roomrentals",
                column: "roomid");

            migrationBuilder.CreateIndex(
                name: "ix_roomrentals_tenantid",
                table: "roomrentals",
                column: "tenantid");

            migrationBuilder.CreateIndex(
                name: "ix_rooms_floorid",
                table: "rooms",
                column: "floorid");

            migrationBuilder.CreateIndex(
                name: "ix_rooms_roomstatusid",
                table: "rooms",
                column: "roomstatusid");

            migrationBuilder.CreateIndex(
                name: "ix_rooms_userid",
                table: "rooms",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "ix_shoplocations_roomid",
                table: "shoplocations",
                column: "roomid");

            migrationBuilder.CreateIndex(
                name: "ix_shoplocations_shopid",
                table: "shoplocations",
                column: "shopid");

            migrationBuilder.CreateIndex(
                name: "ix_shops_businessareaid",
                table: "shops",
                column: "businessareaid");

            migrationBuilder.CreateIndex(
                name: "ix_shops_userid",
                table: "shops",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "ix_tenants_tenanttypeid",
                table: "tenants",
                column: "tenanttypeid");
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

            migrationBuilder.DropTable(
                name: "carts");

            migrationBuilder.DropTable(
                name: "chapawebhookresponses");

            migrationBuilder.DropTable(
                name: "chatversions");

            migrationBuilder.DropTable(
                name: "floorprices");

            migrationBuilder.DropTable(
                name: "IdentityUserLogin<string>");

            migrationBuilder.DropTable(
                name: "IdentityUserToken<string>");

            migrationBuilder.DropTable(
                name: "invoices");

            migrationBuilder.DropTable(
                name: "itemimages");

            migrationBuilder.DropTable(
                name: "itemprices");

            migrationBuilder.DropTable(
                name: "maintenancerequests");

            migrationBuilder.DropTable(
                name: "notifications");

            migrationBuilder.DropTable(
                name: "orderitems");

            migrationBuilder.DropTable(
                name: "rentalagreementterminations");

            migrationBuilder.DropTable(
                name: "roomprices");

            migrationBuilder.DropTable(
                name: "roomproperties");

            migrationBuilder.DropTable(
                name: "roompropertytypeoptions");

            migrationBuilder.DropTable(
                name: "roomrentalpayments");

            migrationBuilder.DropTable(
                name: "shoplocations");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "chats");

            migrationBuilder.DropTable(
                name: "invoicestatuses");

            migrationBuilder.DropTable(
                name: "buildingemployees");

            migrationBuilder.DropTable(
                name: "maintenancestatuses");

            migrationBuilder.DropTable(
                name: "maintenancetypes");

            migrationBuilder.DropTable(
                name: "notificationstatuses");

            migrationBuilder.DropTable(
                name: "notificationtypes");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "roompropertytypes");

            migrationBuilder.DropTable(
                name: "paymentmodes");

            migrationBuilder.DropTable(
                name: "paymenttypes");

            migrationBuilder.DropTable(
                name: "roomrentals");

            migrationBuilder.DropTable(
                name: "chatstatuses");

            migrationBuilder.DropTable(
                name: "servicecategories");

            migrationBuilder.DropTable(
                name: "itemcategories");

            migrationBuilder.DropTable(
                name: "shops");

            migrationBuilder.DropTable(
                name: "rooms");

            migrationBuilder.DropTable(
                name: "tenants");

            migrationBuilder.DropTable(
                name: "businessareas");

            migrationBuilder.DropTable(
                name: "floors");

            migrationBuilder.DropTable(
                name: "roomstatues");

            migrationBuilder.DropTable(
                name: "tenanttypes");

            migrationBuilder.DropTable(
                name: "buildings");

            migrationBuilder.DropTable(
                name: "buildingtypes");

            migrationBuilder.DropTable(
                name: "locations");

            migrationBuilder.DropTable(
                name: "owners");

            migrationBuilder.DropTable(
                name: "usetypes");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "documentes");

            migrationBuilder.DropTable(
                name: "ownershiptypes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "genders");
        }
    }
}
