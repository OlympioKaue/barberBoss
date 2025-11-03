using barberBoss.Communication.Enum;

namespace barberBoss.Communication.Request.Billings;


public class RequestBillings
{
    public string BarberName { get; set; } = string.Empty;
    public string ClientName { get; set; } = string.Empty;
    public string ServiceName { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
}
