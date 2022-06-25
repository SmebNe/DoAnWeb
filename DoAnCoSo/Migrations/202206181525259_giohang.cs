namespace DoAnCoSo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class giohang : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GioHangs",
                c => new
                    {
                        masach = c.Int(nullable: false, identity: true),
                        tensach = c.String(),
                        hinh = c.String(),
                        giaban = c.Double(nullable: false),
                        iSoluong = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.masach);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GioHangs");
        }
    }
}
