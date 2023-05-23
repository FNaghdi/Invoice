using WebApplication5.Implementaions;
using Domain.Model;
using Business.Services;
using Business.Implementaions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PersonContext>();

builder.Services.AddScoped<IProductAction, ProductAction>();
builder.Services.AddScoped<IPersonAction, PersonAction>();
builder.Services.AddScoped<IPurchaseinvoiceAction, PurchaseinvoiceAction>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseRouting();
app.MapControllers();




app.Run();
