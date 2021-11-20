using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(1)]
    public class MerchPackRequestTable : Migration
    {
        public override void Up()
        {
            Create
                .Table("merch_pack_request")
                .WithColumn("mpr_id").AsInt64().Identity().PrimaryKey()
                .WithColumn("mpr_status_id").AsInt32().NotNullable()
                .WithColumn("merch_pack_type_id").AsInt32().NotNullable()
                .WithColumn("employee_id").AsInt64().NotNullable()
                .WithColumn("mpr_create_date").AsDateTime().NotNullable()
                .WithColumn("mpr_change_date").AsDateTime().Nullable();
        }

        public override void Down()
        {
            Delete.Table("merch_pack_request");
        }
    }
}