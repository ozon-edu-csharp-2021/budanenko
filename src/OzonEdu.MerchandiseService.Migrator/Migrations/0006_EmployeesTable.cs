using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(6)]
    public class EmployeesTable : Migration
    {
    public override void Up()
    {
        Create
            .Table("employees")
            .WithColumn("employee_id").AsInt64().Identity().PrimaryKey()
            .WithColumn("last_name").AsString().NotNullable()
            .WithColumn("first_name").AsString().NotNullable()
            .WithColumn("middle_name").AsString().Nullable()
            .WithColumn("birth_date").AsDate().NotNullable()
            .WithColumn("email").AsString().NotNullable()
            .WithColumn("hiring_date").AsDate().Nullable()
            .WithColumn("clothing_size_id").AsInt32().Nullable()
            .WithColumn("firing_date").AsDate().Nullable();
    }

    public override void Down()
    {
        Delete.Table("employees");
    }
    }
}