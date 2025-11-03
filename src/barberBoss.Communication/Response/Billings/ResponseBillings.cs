using barberBoss.Communication.Enum;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace barberBoss.Communication.Response.Billings;

public class ResponseBillings
{
    public string BarberName { get; set; } = string.Empty;
    public string ClientName { get; set; } = string.Empty;
    public string ServiceName { get; set; } = string.Empty;
    [JsonIgnore]
    public decimal Amount { get; set; }
    [JsonPropertyName("Amount")]
    public string AmountFormat => Amount.ToString("F2");
    public DateTime CreatedAt { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public PaymentMethod PaymentMethod { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Status Status { get; set; }
}
