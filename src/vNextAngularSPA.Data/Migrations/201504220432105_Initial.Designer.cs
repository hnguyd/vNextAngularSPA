using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using System;
using vNextAngularSPA.Data;

namespace vNextAngularSPA.Data.Migrations
{
    [ContextType(typeof(vNextAngularSPA.Data.ApplicationDbContext))]
    public partial class Initial : IMigrationMetadata
    {
        string IMigrationMetadata.MigrationId
        {
            get
            {
                return "201504220432105_Initial";
            }
        }
        
        string IMigrationMetadata.ProductVersion
        {
            get
            {
                return "7.0.0-beta3-12166";
            }
        }
        
        IModel IMigrationMetadata.TargetModel
        {
            get
            {
                var builder = new BasicModelBuilder();
                
                builder.Entity("Microsoft.AspNet.Identity.IdentityRole", b =>
                    {
                        b.Property<string>("ConcurrencyStamp")
                            .ConcurrencyToken();
                        b.Property<string>("Id")
                            .GenerateValueOnAdd();
                        b.Property<string>("Name");
                        b.Property<string>("NormalizedName");
                        b.Key("Id");
                        b.ForRelational().Table("AspNetRoles");
                    });
                
                builder.Entity("Microsoft.AspNet.Identity.IdentityRoleClaim`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.Property<string>("ClaimType");
                        b.Property<string>("ClaimValue");
                        b.Property<int>("Id")
                            .GenerateValueOnAdd();
                        b.Property<string>("RoleId");
                        b.Key("Id");
                        b.ForRelational().Table("AspNetRoleClaims");
                    });
                
                builder.Entity("Microsoft.AspNet.Identity.IdentityUserClaim`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.Property<string>("ClaimType");
                        b.Property<string>("ClaimValue");
                        b.Property<int>("Id")
                            .GenerateValueOnAdd();
                        b.Property<string>("UserId");
                        b.Key("Id");
                        b.ForRelational().Table("AspNetUserClaims");
                    });
                
                builder.Entity("Microsoft.AspNet.Identity.IdentityUserLogin`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.Property<string>("LoginProvider");
                        b.Property<string>("ProviderDisplayName");
                        b.Property<string>("ProviderKey");
                        b.Property<string>("UserId");
                        b.Key("LoginProvider", "ProviderKey");
                        b.ForRelational().Table("AspNetUserLogins");
                    });
                
                builder.Entity("Microsoft.AspNet.Identity.IdentityUserRole`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.Property<string>("RoleId");
                        b.Property<string>("UserId");
                        b.Key("UserId", "RoleId");
                        b.ForRelational().Table("AspNetUserRoles");
                    });
                
                builder.Entity("vNextAngularSPA.Data.ApplicationUser", b =>
                    {
                        b.Property<int>("AccessFailedCount");
                        b.Property<string>("ConcurrencyStamp")
                            .ConcurrencyToken();
                        b.Property<string>("Email");
                        b.Property<bool>("EmailConfirmed");
                        b.Property<string>("Id")
                            .GenerateValueOnAdd();
                        b.Property<bool>("LockoutEnabled");
                        b.Property<DateTimeOffset?>("LockoutEnd");
                        b.Property<string>("NormalizedEmail");
                        b.Property<string>("NormalizedUserName");
                        b.Property<string>("PasswordHash");
                        b.Property<string>("PhoneNumber");
                        b.Property<bool>("PhoneNumberConfirmed");
                        b.Property<string>("SecurityStamp");
                        b.Property<bool>("TwoFactorEnabled");
                        b.Property<string>("UserName");
                        b.Key("Id");
                        b.ForRelational().Table("AspNetUsers");
                    });
                
                builder.Entity("vNextAngularSPA.Model.BookmarkedPlace", b =>
                    {
                        b.Property<string>("Address");
                        b.Property<string>("Category");
                        b.Property<int>("Id");
                        b.Property<decimal>("Rating");
                        b.Property<DateTime?>("TS");
                        b.Property<string>("UserName");
                        b.Property<string>("VenueID");
                        b.Property<string>("VenueName");
                        b.Key("Id");
                    });
                
                builder.Entity("Microsoft.AspNet.Identity.IdentityRoleClaim`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.ForeignKey("Microsoft.AspNet.Identity.IdentityRole", "RoleId");
                    });
                
                builder.Entity("Microsoft.AspNet.Identity.IdentityUserClaim`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.ForeignKey("vNextAngularSPA.Data.ApplicationUser", "UserId");
                    });
                
                builder.Entity("Microsoft.AspNet.Identity.IdentityUserLogin`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.ForeignKey("vNextAngularSPA.Data.ApplicationUser", "UserId");
                    });
                
                return builder.Model;
            }
        }
    }
}