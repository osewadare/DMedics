using Microsoft.EntityFrameworkCore.Migrations;

namespace DMedics.Infrastructure.Migrations
{
    public partial class movedpaymentsecrettoAppointmentEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentSecret",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "ReferralSource",
                table: "Customers",
                type: "TEXT",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 250);

            migrationBuilder.AddColumn<string>(
                name: "PaymentSecret",
                table: "Appointments",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentSecret",
                table: "Appointments");

            migrationBuilder.AlterColumn<string>(
                name: "ReferralSource",
                table: "Customers",
                type: "TEXT",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentSecret",
                table: "Customers",
                type: "TEXT",
                nullable: true);
        }
    }
}
