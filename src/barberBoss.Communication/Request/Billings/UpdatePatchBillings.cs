using barberBoss.Communication.Enum;

namespace barberBoss.Communication.Request.Billings;

public class UpdatePatchBillings
{
    public decimal? Amount { get; set; }
    public PaymentMethod? PaymentMethod { get; set; }
}
