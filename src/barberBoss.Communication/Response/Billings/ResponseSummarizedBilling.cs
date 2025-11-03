namespace barberBoss.Communication.Response.Billings;

public record class ResponseSummarizedBilling(int IdBilling, string BarberName, string ClientName, string ServiceName) { }
