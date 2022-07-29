using GraphQL.MicrosoftDI;
using GraphQL.Server;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using Lemonade.EntityFramework;
using Lemonade.Notes;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DrinksContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
});
// builder.Services.AddDbContext<OrdersContext>(options =>
// {
//     options.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
// });
builder.Services.AddSingleton<ISchema, DrinksSchema>(services => new DrinksSchema(new SelfActivatingServiceProvider(services)));
// builder.Services.AddSingleton<ISchema, OrdersSchema>(services => new OrdersSchema(new SelfActivatingServiceProvider(services)));

builder.Services.AddGraphQL(options =>
                {
                    options.EnableMetrics = true;
                })
                .AddSystemTextJson();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("*")
                   .AllowAnyHeader();
        });
});

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Lemonade", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lemonade v1"));
    app.UseGraphQLAltair();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.UseGraphQL<ISchema>();

app.Run();
