namespace DoAnCoSo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Macbooks",
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
            
            CreateTable(
                "dbo.MacOS",
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
            
            CreateTable(
                "dbo.IMacs",
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
            
            CreateTable(
                "dbo.MHGamings",
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
            
            CreateTable(
                "dbo.MHVanPhongs",
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
            
            CreateTable(
                "dbo.PCGamings",
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
            
            CreateTable(
                "dbo.PCVanPhongs",
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
            DropTable("dbo.PCVanPhongs");
            DropTable("dbo.PCGamings");
            DropTable("dbo.MHVanPhongs");
            DropTable("dbo.MHGamings");
            DropTable("dbo.IMacs");
            DropTable("dbo.MacOS");
            DropTable("dbo.Macbooks");
        }
    }
}
