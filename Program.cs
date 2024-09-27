using carpark_info_assignment.Business;
using carpark_info_assignment.CarparkDb;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<CarparkBusiness>();
builder.Services.AddScoped<MyFavouriteBusiness>();
builder.Services.AddScoped<CsvService>();
builder.Services.AddDbContext<SQLiteDbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();