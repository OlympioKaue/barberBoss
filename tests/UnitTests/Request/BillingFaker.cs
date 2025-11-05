using barberBoss.Communication.Enum;
using barberBoss.Communication.Request.Billings;
using Bogus;

namespace UnitFakerTests.Request;

public class BillingFaker
{
    public static RequestBillings FakerBilling()
    {
        var faker = new Faker<RequestBillings>()
            .RuleFor(src => src.ClientName, faker => faker.Name.FindName())
            .RuleFor(src => src.BarberName, faker => faker.Name.FindName())
            .RuleFor(src => src.PaymentMethod, faker => (PaymentMethod)faker.Random.Int(2, 5));

        return faker.Generate();
    }
}
