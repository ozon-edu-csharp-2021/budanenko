using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(6)]
    public class MerchItemsTable : Migration
    {
    public override void Up()
    {
        Create
            .Table("merch_items")
            .WithColumn("merch_item_id").AsInt64().Identity().PrimaryKey()
            .WithColumn("mpr_id").AsInt64().NotNullable()
            .WithColumn("merch_item_type_id").AsInt32().NotNullable()
            .WithColumn("merch_item_status_id").AsInt32().NotNullable()
            .WithColumn("sku_id").AsInt64().Nullable();
    }

    public override void Down()
    {
        Delete.Table("merch_items");
    }
    }
}