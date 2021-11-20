using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(5)]
    public class MerchPackItemsMap : Migration
    {
        public override void Up()
        {
            Create
                .Table("merch_pack_items_map")
                .WithColumn("merch_pack_type_id").AsInt32().PrimaryKey()
                .WithColumn("merch_item_type_id").AsInt32().PrimaryKey();
        }

        public override void Down()
        {
            Delete.Table("merch_pack_items_map");
        }
    }
}