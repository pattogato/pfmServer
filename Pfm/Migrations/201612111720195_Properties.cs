namespace Pfm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Properties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "LocalId", c => c.Guid(nullable: false));
            AddColumn("dbo.Transactions", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "Name");
            DropColumn("dbo.Transactions", "LocalId");
        }
    }
}
