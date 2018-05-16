namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        streetName = c.String(nullable: false, maxLength: 50),
                        streetNumber = c.Int(nullable: false),
                        theClient_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Clients", t => t.theClient_id)
                .Index(t => t.theClient_id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idCard = c.String(nullable: false),
                        name = c.String(nullable: false, maxLength: 50),
                        lastname = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "theClient_id", "dbo.Clients");
            DropIndex("dbo.Addresses", new[] { "theClient_id" });
            DropTable("dbo.Clients");
            DropTable("dbo.Addresses");
        }
    }
}
