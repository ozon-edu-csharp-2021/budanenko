using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(7)]
    public class ClothingSizesTable : Migration
    {
        public override void Up()
        {
            Create
                .Table("clothing_sizes")
                .WithColumn("clothing_size_id").AsInt32().Identity().PrimaryKey()
                .WithColumn("clothing_size_name").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("clothing_sizes");
        }
    }
}