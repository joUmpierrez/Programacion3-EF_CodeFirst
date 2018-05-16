namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeIdCard : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Clients", name: "idCard", newName: "Id Card");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Clients", name: "Id Card", newName: "idCard");
        }
    }
}
