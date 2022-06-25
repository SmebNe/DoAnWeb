namespace DoAnCoSo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableWindows : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Windows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ten = c.String(),
                        TrangThai = c.String(),
                        PhanLoai = c.String(),
                        MoTa = c.String(),
                        ThongSo = c.String(),
                        NamSanXuat = c.String(),
                        Gia = c.Double(nullable: false),
                        Hinh = c.String(),
                        Rong = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Windows");
        }
    }
}
