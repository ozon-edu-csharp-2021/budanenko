using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(4)]
    public class MerchItemTypeTable : Migration
    {
        public override void Up()
        {
            Create
                .Table("merch_item_type")
                .WithColumn("merch_item_type_id").AsInt32().Identity().PrimaryKey()
                .WithColumn("merch_item_type_name").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("merch_item_type");
        }
    }
}