namespace Pfm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tags : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        TransactionId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Transactions", t => t.TransactionId, cascadeDelete: true)
                .Index(t => t.TransactionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tags", "TransactionId", "dbo.Transactions");
            DropIndex("dbo.Tags", new[] { "TransactionId" });
            DropTable("dbo.Tags");
        }
    }
}
