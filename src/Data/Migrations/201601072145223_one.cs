namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class one : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Centers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExternalId = c.Int(nullable: false),
                        Source = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Leads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        IpAddress = c.String(),
                        CenterId = c.Int(nullable: false),
                        Url = c.String(),
                        UserAgent = c.String(),
                        ClientName = c.String(),
                        ClientPhone = c.String(),
                        ClientEmail = c.String(),
                        ClientMessage = c.String(),
                        Readed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Centers", t => t.CenterId, cascadeDelete: true)
                .Index(t => t.CenterId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExternalId = c.Int(nullable: false),
                        Source = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Project = c.String(maxLength: 100),
                        RelationCompany = c.String(maxLength: 100),
                        RecommendBussiness = c.Boolean(nullable: false),
                        Rating = c.Single(nullable: false),
                        Like = c.Int(nullable: false),
                        Text = c.String(maxLength: 2000),
                        PatientId = c.Int(),
                        ExpertId = c.Int(nullable: true),
                        DoctorId = c.Int(nullable: true),
                        CenterId = c.Int(nullable: true),
                        ParentReview_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Centers", t => t.CenterId, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.DoctorId)
                .ForeignKey("dbo.Experts", t => t.ExpertId)
                .ForeignKey("dbo.Experts", t => t.ParentReview_Id)
                .ForeignKey("dbo.Patients", t => t.PatientId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.PatientId)
                .Index(t => t.ExpertId)
                .Index(t => t.DoctorId)
                .Index(t => t.CenterId)
                .Index(t => t.ParentReview_Id);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExternalId = c.Int(nullable: false),
                        Source = c.String(),
                        ImageId = c.Int(),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Images", t => t.ImageId)
                .Index(t => t.ImageId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        AlternateName = c.String(),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Experts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExternalId = c.Int(nullable: false),
                        Description = c.String(maxLength: 500),
                        Url = c.String(nullable: false, maxLength: 200),
                        Name = c.String(maxLength: 200),
                        ListingTitle = c.String(maxLength: 200),
                        Slogan = c.String(maxLength: 400),
                        InBusinessSince = c.Int(),
                        ServiceRadius = c.Int(nullable: false),
                        Email = c.String(maxLength: 200),
                        FaxNumber = c.String(maxLength: 10),
                        Telephone = c.String(maxLength: 10),
                        WebSite = c.String(maxLength: 200),
                        UserId = c.String(maxLength: 128),
                        ImageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Images", t => t.ImageId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.Url, unique: true, name: "UrlIndex")
                .Index(t => t.UserId)
                .Index(t => t.ImageId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExternalId = c.Int(nullable: false),
                        Source = c.String(),
                        FirstName = c.String(maxLength: 50),
                        MiddleName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        DOB = c.DateTime(storeType: "smalldatetime"),
                        Email = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Reviews", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reviews", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Reviews", "ParentReview_Id", "dbo.Experts");
            DropForeignKey("dbo.Experts", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reviews", "ExpertId", "dbo.Experts");
            DropForeignKey("dbo.Experts", "ImageId", "dbo.Images");
            DropForeignKey("dbo.Reviews", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Doctors", "ImageId", "dbo.Images");
            DropForeignKey("dbo.Reviews", "CenterId", "dbo.Centers");
            DropForeignKey("dbo.Leads", "CenterId", "dbo.Centers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Experts", new[] { "ImageId" });
            DropIndex("dbo.Experts", new[] { "UserId" });
            DropIndex("dbo.Experts", "UrlIndex");
            DropIndex("dbo.Doctors", new[] { "ImageId" });
            DropIndex("dbo.Reviews", new[] { "ParentReview_Id" });
            DropIndex("dbo.Reviews", new[] { "CenterId" });
            DropIndex("dbo.Reviews", new[] { "DoctorId" });
            DropIndex("dbo.Reviews", new[] { "ExpertId" });
            DropIndex("dbo.Reviews", new[] { "PatientId" });
            DropIndex("dbo.Reviews", new[] { "UserId" });
            DropIndex("dbo.Leads", new[] { "CenterId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Patients");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Experts");
            DropTable("dbo.Images");
            DropTable("dbo.Doctors");
            DropTable("dbo.Reviews");
            DropTable("dbo.Leads");
            DropTable("dbo.Centers");
        }
    }
}
