using GraphQL.Types;
using Lemonade.EntityFramework;

namespace Lemonade.Notes;

public class DrinksQuery : ObjectGraphType
{
    public DrinksQuery()
    {
        Field<ListGraphType<DrinkType>>("drinksFromEF", resolve: context =>
        {
            var drinksContext = context.RequestServices.GetRequiredService<DrinksContext>();
            return drinksContext.Drinks.ToList();
        }
        );
        
        Field<ListGraphType<OrderType>>("ordersFromEF", resolve: context =>
        {
            var ordersContext = context.RequestServices.GetRequiredService<DrinksContext>();
            return ordersContext.Orders.ToList();
        }
        );
    }
}

// public class OrdersQuery : ObjectGraphType
// {
//     public OrdersQuery()
//     {
//         Field<ListGraphType<OrderType>>("ordersFromEF", resolve: context =>
//         {
//             var ordersContext = context.RequestServices.GetRequiredService<OrdersContext>();
//             return ordersContext.Orders.ToList();
//         }
//         );
//     }
// }