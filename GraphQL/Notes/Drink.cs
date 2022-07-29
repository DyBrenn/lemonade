namespace Lemonade.Notes;

public class Drink
{
  public Guid Id { get; set; }
  public string Flavor { get; set; }
  public string Size { get; set; }
  public decimal Price { get; set; }
}

public class Order
{
  public Guid Id { get; set; }
  public string Name { get; set; }
  public string Contact { get; set; }
  public decimal Price { get; set; }
  public string[] DrinkIds { get; set; }
}