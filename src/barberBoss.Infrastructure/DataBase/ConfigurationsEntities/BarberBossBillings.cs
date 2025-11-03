using barberBoss.Communication.Enum;
using barberBoss.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace barberBoss.Infrastructure.DataBase.ConfigurationsEntities;

internal class BarberBossBillings : IEntityTypeConfiguration<Billing>
{
    public void Configure(EntityTypeBuilder<Billing> builder)
    {
        builder.HasKey(x => x.IdBilling);

        builder.Property(x => x.BarberName).HasColumnType("varchar(80)").HasMaxLength(80).IsRequired();

        builder.Property(x => x.ClientName).HasColumnType("varchar(120)").HasMaxLength(120).IsRequired();

        builder.Property(x => x.ServiceName).HasColumnType("varchar(120)").HasMaxLength(120).IsRequired();

        builder.Property(x => x.Amount).HasColumnType("numeric(10,2)").HasPrecision(10, 2).IsRequired();

        builder.Property(x => x.CreatedAt).IsRequired();

        builder.Property(x => x.PaymentMethod)
               .HasConversion(v => v.ToString(), v => (PaymentMethod)Enum.Parse(typeof(PaymentMethod), v))
               .HasColumnType("varchar(20)")
               .HasMaxLength(10)
               .IsRequired();

        builder.Property(x => x.Status)
               .HasConversion(v => v.ToString(), v => (Status)Enum.Parse(typeof(Status), v))
               .HasColumnType("varchar(20)")
               .HasMaxLength(10)
               .IsRequired();

        AddDateTableBilling(builder);
    }

    private static void AddDateTableBilling(EntityTypeBuilder<Billing> builder)
    {
        builder.HasData(
      new Billing { IdBilling = 1, BillingIdentifier = Guid.NewGuid(), BarberName = "Kauê Olympio", ClientName = "Lucas Pereira", ServiceName = "Corte", Amount = 35.00m, CreatedAt = new DateTime(2025, 9, 1, 10, 15, 00), PaymentMethod = PaymentMethod.Pix, Status = Status.Paid, UpdateAt = null },
      new Billing { IdBilling = 2, BillingIdentifier = Guid.NewGuid(), BarberName = "Kauê Olympio", ClientName = "Ruan Fernandes", ServiceName = "Barba", Amount = 25.00m, CreatedAt = new DateTime(2025, 9, 2, 14, 45, 00), PaymentMethod = PaymentMethod.Money, Status = Status.Paid, UpdateAt = null },
      new Billing { IdBilling = 3, BillingIdentifier = Guid.NewGuid(), BarberName = "Kauê Olympio", ClientName = "Pedro Oliveira", ServiceName = "Corte e Barba", Amount = 60.00m, CreatedAt = new DateTime(2025, 9, 3, 9, 10, 00), PaymentMethod = PaymentMethod.DebitCard, Status = Status.Paid, UpdateAt = null },
      new Billing { IdBilling = 4, BillingIdentifier = Guid.NewGuid(), BarberName = "Kauê Olympio", ClientName = "Gabriel Lima", ServiceName = "Corte", Amount = 35.00m, CreatedAt = new DateTime(2025, 9, 4, 13, 20, 00), PaymentMethod = PaymentMethod.DebitCard, Status = Status.Paid, UpdateAt = null },
      new Billing { IdBilling = 5, BillingIdentifier = Guid.NewGuid(), BarberName = "Kauê Olympio", ClientName = "João Vitor", ServiceName = "Corte e Barba", Amount = 60.00m, CreatedAt = new DateTime(2025, 9, 5, 11, 50, 00), PaymentMethod = PaymentMethod.Pix, Status = Status.Paid, UpdateAt = null },
      new Billing { IdBilling = 6, BillingIdentifier = Guid.NewGuid(), BarberName = "Kauê Olympio", ClientName = "André Santos", ServiceName = "Barba", Amount = 25.00m, CreatedAt = new DateTime(2025, 9, 6, 16, 25, 00), PaymentMethod = PaymentMethod.Pix, Status = Status.Paid, UpdateAt = null },
      new Billing { IdBilling = 7, BillingIdentifier = Guid.NewGuid(), BarberName = "Kauê Olympio", ClientName = "Felipe Rocha", ServiceName = "Corte", Amount = 35.00m, CreatedAt = new DateTime(2025, 9, 7, 12, 05, 00), PaymentMethod = PaymentMethod.Pix, Status = Status.Paid, UpdateAt = null },
      new Billing { IdBilling = 8, BillingIdentifier = Guid.NewGuid(), BarberName = "Kauê Olympio", ClientName = "Matheus Almeida", ServiceName = "Corte e Barba", Amount = 60.00m, CreatedAt = new DateTime(2025, 9, 8, 17, 40, 00), PaymentMethod = PaymentMethod.Pix, Status = Status.Paid, UpdateAt = null },
      new Billing { IdBilling = 9, BillingIdentifier = Guid.NewGuid(), BarberName = "Kauê Olympio", ClientName = "Carlos Eduardo", ServiceName = "Corte", Amount = 35.00m, CreatedAt = new DateTime(2025, 9, 9, 15, 30, 00), PaymentMethod = PaymentMethod.Pix, Status = Status.Paid, UpdateAt = null },
      new Billing { IdBilling = 10, BillingIdentifier = Guid.NewGuid(), BarberName = "Kauê Olympio", ClientName = "Renan Silva", ServiceName = "Barba", Amount = 25.00m, CreatedAt = new DateTime(2025, 9, 10, 11, 10, 00), PaymentMethod = PaymentMethod.Pix, Status = Status.Paid, UpdateAt = null },
      new Billing { IdBilling = 11, BillingIdentifier = Guid.NewGuid(), BarberName = "Kauê Olympio", ClientName = "Diego Souza", ServiceName = "Corte", Amount = 35.00m, CreatedAt = new DateTime(2025, 9, 11, 13, 00, 00), PaymentMethod = PaymentMethod.CreditCard, Status = Status.Paid, UpdateAt = null },
      new Billing { IdBilling = 12, BillingIdentifier = Guid.NewGuid(), BarberName = "Kauê Olympio", ClientName = "Marcos Paulo", ServiceName = "Corte e Barba", Amount = 60.00m, CreatedAt = new DateTime(2025, 9, 12, 14, 15, 00), PaymentMethod = PaymentMethod.Pix, Status = Status.Paid, UpdateAt = null },
      new Billing { IdBilling = 13, BillingIdentifier = Guid.NewGuid(), BarberName = "Kauê Olympio", ClientName = "Vinicius Costa", ServiceName = "Corte", Amount = 35.00m, CreatedAt = new DateTime(2025, 9, 13, 10, 35, 00), PaymentMethod = PaymentMethod.Pix, Status = Status.Paid, UpdateAt = null },
      new Billing { IdBilling = 14, BillingIdentifier = Guid.NewGuid(), BarberName = "Kauê Olympio", ClientName = "Thiago Oliveira", ServiceName = "Barba", Amount = 25.00m, CreatedAt = new DateTime(2025, 9, 14, 15, 45, 00), PaymentMethod = PaymentMethod.Pix, Status = Status.Paid, UpdateAt = null },
      new Billing { IdBilling = 15, BillingIdentifier = Guid.NewGuid(), BarberName = "Kauê Olympio", ClientName = "Paulo Henrique", ServiceName = "Corte", Amount = 35.00m, CreatedAt = new DateTime(2025, 9, 15, 9, 25, 00), PaymentMethod = PaymentMethod.Pix, Status = Status.Paid, UpdateAt = null },
      new Billing { IdBilling = 16, BillingIdentifier = Guid.NewGuid(), BarberName = "Kauê Olympio", ClientName = "Guilherme Moraes", ServiceName = "Corte e Barba", Amount = 60.00m, CreatedAt = new DateTime(2025, 9, 17, 16, 10, 00), PaymentMethod = PaymentMethod.CreditCard, Status = Status.Paid, UpdateAt = null },
      new Billing { IdBilling = 17, BillingIdentifier = Guid.NewGuid(), BarberName = "Kauê Olympio", ClientName = "Bruno Ferreira", ServiceName = "Corte", Amount = 35.00m, CreatedAt = new DateTime(2025, 9, 20, 11, 00, 00), PaymentMethod = PaymentMethod.Pix, Status = Status.Paid, UpdateAt = null },
      new Billing { IdBilling = 18, BillingIdentifier = Guid.NewGuid(), BarberName = "Kauê Olympio", ClientName = "Eduardo Nunes", ServiceName = "Barba", Amount = 25.00m, CreatedAt = new DateTime(2025, 9, 24, 15, 55, 00), PaymentMethod = PaymentMethod.Pix, Status = Status.Paid, UpdateAt = null },
      new Billing { IdBilling = 19, BillingIdentifier = Guid.NewGuid(), BarberName = "Kauê Olympio", ClientName = "Rodrigo Martins", ServiceName = "Corte e Barba", Amount = 60.00m, CreatedAt = new DateTime(2025, 9, 27, 13, 45, 00), PaymentMethod = PaymentMethod.CreditCard, Status = Status.Paid, UpdateAt = null },
      new Billing { IdBilling = 20, BillingIdentifier = Guid.NewGuid(), BarberName = "Kauê Olympio", ClientName = "Alexandre Souza", ServiceName = "Corte", Amount = 35.00m, CreatedAt = new DateTime(2025, 9, 30, 10, 30, 00), PaymentMethod = PaymentMethod.CreditCard, Status = Status.Paid, UpdateAt = null }
  );
    }
}
