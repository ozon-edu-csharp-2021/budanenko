using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(2)]
    public class MerchPackRequestStatusTable : Migration
    {
        public override void Up()
        {
            Create
                .Table("merch_pack_request_status")
                .WithColumn("mpr_status_id").AsInt32().Identity().PrimaryKey()
                .WithColumn("mpr_status_name").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("merch_pack_request_status");
        }
    }
}