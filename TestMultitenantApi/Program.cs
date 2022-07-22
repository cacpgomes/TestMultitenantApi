using Finbuckle.MultiTenant;
using Microsoft.EntityFrameworkCore;
using TestMultitenantApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Finbuckle MultiTenant services
builder.Services.AddMultiTenant<TenantInfo>()
    .WithConfigurationStore()
    .WithRouteStrategy();

// Register the db context, but do not specify a provider/connection string since
// these vary by tenant.
builder.Services.AddDbContext<CarContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Register MultiTenant
// Be sure to call it before calling UseEndpoints() and other middleware which will use per-tenant functionality, e.g. UseAuthentication().
app.UseMultiTenant();

app.UseAuthorization();

app.MapControllers();

app.Run();

