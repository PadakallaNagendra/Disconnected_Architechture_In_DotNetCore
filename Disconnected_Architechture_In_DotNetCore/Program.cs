using Disconnected_Architechture_In_DotNetCore.InterFace;
using Disconnected_Architechture_In_DotNetCore.Repositary;
using Disconnected_Architechture_In_DotNetCore.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICustomerRepositary, CustomerRepositary>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IDashboardRepositary, DashRepositary>();
builder.Services.AddScoped<IDashboardService, DashboardServices>();
//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(builder =>
//    {
//        builder.AllowAnyOrigin();
//        builder.AllowAnyMethod();
//        builder.AllowAnyHeader();
//    });
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors();

app.MapControllers();

app.Run();
