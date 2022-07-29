using GraphQL;
using GraphQL.Types;
using Lemonade.EntityFramework;

namespace Lemonade.Notes
{
    public class DrinksMutation : ObjectGraphType
    {
        public DrinksMutation()
        {
            Field<DrinkType>(
                "createDrink",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "flavor"},
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "size"},
                    new QueryArgument<NonNullGraphType<DecimalGraphType>> { Name = "price"}
                ),
                resolve: context =>
                {
                    var flavor = context.GetArgument<string>("flavor");
                    var size = context.GetArgument<string>("size");
                    var price = context.GetArgument<decimal>("price");
                    var DrinksContext = context.RequestServices.GetRequiredService<DrinksContext>();
                    var drink = new Drink
                    {
                        Flavor = flavor,
                        Size = size,
                        Price = price
                    };
                    DrinksContext.Drinks.Add(drink);
                    DrinksContext.SaveChanges();
                    return drink;
                }
            );

            Field<OrderType>(
                "createOrder",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name"},
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "contact"},
                    new QueryArgument<NonNullGraphType<DecimalGraphType>> { Name = "price"},
                    new QueryArgument<NonNullGraphType<ListGraphType<StringGraphType>>> { Name = "drinkIds"}
                ),
                resolve: context =>
                {
                    var name = context.GetArgument<string>("name");
                    var contact = context.GetArgument<string>("contact");
                    var price = context.GetArgument<decimal>("price");
                    var drinkIds = context.GetArgument<string[]>("drinkIds");
                    var ordersContext = context.RequestServices.GetRequiredService<DrinksContext>();
                    var order = new Order
                    {
                        Name = name,
                        Contact = contact,
                        Price = price,
                        DrinkIds = drinkIds
                    };
                    ordersContext.Orders.Add(order);
                    ordersContext.SaveChanges();
                    return order;
                }
            );
        }
    }
}