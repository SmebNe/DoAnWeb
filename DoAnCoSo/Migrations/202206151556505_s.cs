namespace DoAnCoSo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class s : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DonHanggs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        thanhtoan = c.Boolean(nullable: false),
                        giaohang = c.Boolean(nullable: false),
                        ngaydat = c.DateTime(nullable: false),
                        ngaygiao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DonHanggs");
        }
    }
}
