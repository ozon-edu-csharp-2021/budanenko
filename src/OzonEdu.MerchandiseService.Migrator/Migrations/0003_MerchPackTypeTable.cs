using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(3)]
    public class MerchPackTypeTable : Migration
    {
        public override void Up()
        {
            Create
                .Table("merch_pack_type")
                .WithColumn("merch_pack_type_id").AsInt32().Identity().PrimaryKey()
                .WithColumn("merch_pack_type_name").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("merch_pack_type");
        }
    }
}