namespace Itancan.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreateCarTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_car",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    RegistrationNumber = c.String(nullable: false, maxLength: 25),
                    CarModel = c.String(nullable: false, maxLength: 25),
                    CarStatus = c.Int(nullable: false),
                })

                .PrimaryKey(t => t.Id);
          

        }

        public override void Down()
        {
            DropTable("dbo.tbl_car");
        }
    }
}
