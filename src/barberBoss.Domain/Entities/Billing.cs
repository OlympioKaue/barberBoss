using barberBoss.Communication.Enum;

namespace barberBoss.Domain.Entities;

public class Billing
{
    public int IdBilling { get; set; }
    public Guid BillingIdentifier { get; set; } = Guid.NewGuid();
    public string BarberName { get; set; } = string.Empty;
    public string ClientName { get; set; } = string.Empty;
    public string ServiceName { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdateAt { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public Status Status { get; set; }

}
