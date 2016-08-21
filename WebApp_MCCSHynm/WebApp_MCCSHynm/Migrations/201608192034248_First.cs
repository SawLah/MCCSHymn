namespace WebApp_MCCSHynm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hymns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        HynmNumber = c.Int(nullable: false),
                        HynmVerse1 = c.String(),
                        HymnChorus = c.String(),
                        HynmClosing = c.String(),
                        HynmVerse2 = c.String(),
                        HymnVerse3 = c.String(),
                        HymnVerse4 = c.String(),
                        HymnVerse5 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Hymns");
        }
    }
}
