namespace SimpleSubscription.Domain.Entities;

public sealed class Plan : Entity
{
    public string Name { get; private set; } = string.Empty;
    public decimal Price { get; private set; }

    private Plan() { }

    public Plan(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}
