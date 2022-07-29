using GraphQL.Types;

namespace Lemonade.Notes;

public class DrinkType : ObjectGraphType<Drink>{
  public DrinkType()
  {
    Name = "Drink";
    Description = "Drink Type";
    Field(d => d.Id, nullable: false).Description("Drink Id");
    Field(d => d.Flavor, nullable: false).Description("Drink flavor");
    Field(d => d.Size, nullable: false).Description("Drink size");
    Field(d => d.Price, nullable: false).Description("Drink price");
  }
}

public class OrderType : ObjectGraphType<Order>{
  public OrderType()
  {
    Name = "Order";
    Description = "Order Type";
    Field(d => d.Id, nullable: false).Description("Order Id");
    Field(d => d.Name, nullable: false).Description("Name of customer");
    Field(d => d.Contact, nullable: false).Description("Customer contact info");
    Field(d => d.Price, nullable: false).Description("ORder price");
    Field(d => d.DrinkIds, nullable: false).Description("Ids of ordered drinks");
  }
}