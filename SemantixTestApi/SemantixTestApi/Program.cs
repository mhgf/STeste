using SemantixTestApi.Services;
using SemantixTestApi.Services.Contract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICurrencyService, CurrencyService>();
builder.Services.AddHttpClient();

var myCors = "sTesteCors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myCors,
                        builder =>
                        {
                            builder.WithOrigins("http://localhost:3000");
                        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(myCors);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
