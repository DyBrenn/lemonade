using GraphQL.Types;

namespace Lemonade.Notes;

public class DrinksSchema : Schema
{
    public DrinksSchema(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        Query = serviceProvider.GetRequiredService<DrinksQuery>();
        Mutation = serviceProvider.GetRequiredService<DrinksMutation>();
    }
}

// public class OrdersSchema : Schema
// {
//     public OrdersSchema(IServiceProvider serviceProvider) : base(serviceProvider)
//     {
//         Query = serviceProvider.GetRequiredService<NotesQuery>();
//         Mutation = serviceProvider.GetRequiredService<OrdersMutation>();
//     }
// }