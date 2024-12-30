var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ajout de GET
app.MapGet("/calculate-tva", (double price, string country) =>
{
    double tva = country.ToUpper() switch
    {
        "FR" => price * 0.2,
        "BE" => price * 0.21,
        _ => price * 0.2
    };

    return Results.Ok(new
    {
        Price = price,
        Country = country,
        Tva = tva,
        Total = price + tva
    });
});

// exécution de l'app
app.Run();