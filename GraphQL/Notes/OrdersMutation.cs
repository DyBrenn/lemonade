// using GraphQL;
// using GraphQL.Types;
// using Lemonade.EntityFramework;

// namespace Lemonade.Notes
// {
//     public class OrdersMutation : ObjectGraphType
//     {
//         public OrdersMutation()
//         {
//             Field<OrderType>(
//                 "createOrder",
//                 arguments: new QueryArguments(
//                     new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name"},
//                     new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "contact"},
//                     new QueryArgument<NonNullGraphType<DecimalGraphType>> { Name = "price"},
//                     new QueryArgument<NonNullGraphType<ListGraphType<StringGraphType>>> { Name = "drinkIds"}
//                 ),
//                 resolve: context =>
//                 {
//                     var name = context.GetArgument<string>("name");
//                     var contact = context.GetArgument<string>("contact");
//                     var price = context.GetArgument<decimal>("price");
//                     var drinkIds = context.GetArgument<string[]>("drinkIds");
//                     var ordersContext = context.RequestServices.GetRequiredService<OrdersContext>();
//                     var order = new Order
//                     {
//                         Name = name,
//                         Contact = contact,
//                         Price = price,
//                         DrinkIds = drinkIds
//                     };
//                     ordersContext.Orders.Add(order);
//                     ordersContext.SaveChanges();
//                     return order;
//                 }
//             );
//         }
//     }
// }