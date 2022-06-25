namespace DoAnCoSo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        UseName = c.String(maxLength: 200),
                        Passoword = c.String(maxLength: 200),
                        Uid = c.String(nullable: false, maxLength: 300),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Account");
        }
    }
}
