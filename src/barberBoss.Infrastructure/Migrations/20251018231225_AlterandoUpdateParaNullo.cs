using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace barberBoss.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterandoUpdateParaNullo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "Billings",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.InsertData(
                table: "Billings",
                columns: new[] { "IdBilling", "Amount", "BarberName", "BillingIdentifier", "ClientName", "CreatedAt", "PaymentMethod", "ServiceName", "Status", "UpdateAt" },
                values: new object[,]
                {
                    { 1, 35.00m, "Kauê Olympio", new Guid("5a01af9c-9576-4a2a-bd45-277cb26c2d6f"), "Lucas Pereira", new DateTime(2025, 9, 1, 10, 15, 0, 0, DateTimeKind.Unspecified), "Pix", "Corte", "Paid", null },
                    { 2, 25.00m, "Kauê Olympio", new Guid("b0f241ef-9aee-40d9-8f7a-2992e91dbcf2"), "Ruan Fernandes", new DateTime(2025, 9, 2, 14, 45, 0, 0, DateTimeKind.Unspecified), "Money", "Barba", "Paid", null },
                    { 3, 60.00m, "Kauê Olympio", new Guid("e753d40e-e498-4187-89c8-ca40dd724629"), "Pedro Oliveira", new DateTime(2025, 9, 3, 9, 10, 0, 0, DateTimeKind.Unspecified), "DebitCard", "Corte e Barba", "Paid", null },
                    { 4, 35.00m, "Kauê Olympio", new Guid("e3df1d06-f377-4734-9714-dfafe4e6a20c"), "Gabriel Lima", new DateTime(2025, 9, 4, 13, 20, 0, 0, DateTimeKind.Unspecified), "DebitCard", "Corte", "Paid", null },
                    { 5, 60.00m, "Kauê Olympio", new Guid("9cf11b7a-27ed-4f67-b61e-03cbb4c0efb8"), "João Vitor", new DateTime(2025, 9, 5, 11, 50, 0, 0, DateTimeKind.Unspecified), "Pix", "Corte e Barba", "Paid", null },
                    { 6, 25.00m, "Kauê Olympio", new Guid("91c0f9db-2ee1-406e-9b44-ac9235d12380"), "André Santos", new DateTime(2025, 9, 6, 16, 25, 0, 0, DateTimeKind.Unspecified), "Pix", "Barba", "Paid", null },
                    { 7, 35.00m, "Kauê Olympio", new Guid("c2854470-71f5-431d-a002-aedf6f67652d"), "Felipe Rocha", new DateTime(2025, 9, 7, 12, 5, 0, 0, DateTimeKind.Unspecified), "Pix", "Corte", "Paid", null },
                    { 8, 60.00m, "Kauê Olympio", new Guid("291060c6-445e-4d94-89fc-e4c20bc96803"), "Matheus Almeida", new DateTime(2025, 9, 8, 17, 40, 0, 0, DateTimeKind.Unspecified), "Pix", "Corte e Barba", "Paid", null },
                    { 9, 35.00m, "Kauê Olympio", new Guid("e2136411-4a51-473f-a267-bfd219ffd419"), "Carlos Eduardo", new DateTime(2025, 9, 9, 15, 30, 0, 0, DateTimeKind.Unspecified), "Pix", "Corte", "Paid", null },
                    { 10, 25.00m, "Kauê Olympio", new Guid("e9dedf56-1c77-4f29-b566-473693ed9c7a"), "Renan Silva", new DateTime(2025, 9, 10, 11, 10, 0, 0, DateTimeKind.Unspecified), "Pix", "Barba", "Paid", null },
                    { 11, 35.00m, "Kauê Olympio", new Guid("bae477e0-f1ee-4091-8ac8-13fbee2d51ad"), "Diego Souza", new DateTime(2025, 9, 11, 13, 0, 0, 0, DateTimeKind.Unspecified), "CreditCard", "Corte", "Paid", null },
                    { 12, 60.00m, "Kauê Olympio", new Guid("7e4705ba-a7a5-4aaf-8208-d98c84198608"), "Marcos Paulo", new DateTime(2025, 9, 12, 14, 15, 0, 0, DateTimeKind.Unspecified), "Pix", "Corte e Barba", "Paid", null },
                    { 13, 35.00m, "Kauê Olympio", new Guid("f7103f16-5445-4468-ac4e-2bffbb637a4a"), "Vinicius Costa", new DateTime(2025, 9, 13, 10, 35, 0, 0, DateTimeKind.Unspecified), "Pix", "Corte", "Paid", null },
                    { 14, 25.00m, "Kauê Olympio", new Guid("92b01cac-4e05-4924-815a-f09b1b656346"), "Thiago Oliveira", new DateTime(2025, 9, 14, 15, 45, 0, 0, DateTimeKind.Unspecified), "Pix", "Barba", "Paid", null },
                    { 15, 35.00m, "Kauê Olympio", new Guid("b57e91e5-2cd2-4a59-9388-adc309be8426"), "Paulo Henrique", new DateTime(2025, 9, 15, 9, 25, 0, 0, DateTimeKind.Unspecified), "Pix", "Corte", "Paid", null },
                    { 16, 60.00m, "Kauê Olympio", new Guid("3177afda-0617-46db-ac0b-64886b9026d0"), "Guilherme Moraes", new DateTime(2025, 9, 17, 16, 10, 0, 0, DateTimeKind.Unspecified), "CreditCard", "Corte e Barba", "Paid", null },
                    { 17, 35.00m, "Kauê Olympio", new Guid("f7cf6b40-71fd-4f6d-8061-0ffb454966ac"), "Bruno Ferreira", new DateTime(2025, 9, 20, 11, 0, 0, 0, DateTimeKind.Unspecified), "Pix", "Corte", "Paid", null },
                    { 18, 25.00m, "Kauê Olympio", new Guid("7149bad9-45ef-42f1-8e16-9768449d22c8"), "Eduardo Nunes", new DateTime(2025, 9, 24, 15, 55, 0, 0, DateTimeKind.Unspecified), "Pix", "Barba", "Paid", null },
                    { 19, 60.00m, "Kauê Olympio", new Guid("dddf22ff-d1c3-4709-9c15-97aaa0b119ed"), "Rodrigo Martins", new DateTime(2025, 9, 27, 13, 45, 0, 0, DateTimeKind.Unspecified), "CreditCard", "Corte e Barba", "Paid", null },
                    { 20, 35.00m, "Kauê Olympio", new Guid("a1fe27aa-a7ae-472d-b9ff-02826cbc11e7"), "Alexandre Souza", new DateTime(2025, 9, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), "CreditCard", "Corte", "Paid", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "IdBilling",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "IdBilling",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "IdBilling",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "IdBilling",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "IdBilling",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "IdBilling",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "IdBilling",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "IdBilling",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "IdBilling",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "IdBilling",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "IdBilling",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "IdBilling",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "IdBilling",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "IdBilling",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "IdBilling",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "IdBilling",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "IdBilling",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "IdBilling",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "IdBilling",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "IdBilling",
                keyValue: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "Billings",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);
        }
    }
}
