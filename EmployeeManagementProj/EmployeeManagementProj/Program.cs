using Business.Services;
using Data.DataContext;
using Data.REPOSITORY;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

string constr = builder.Configuration.GetConnectionString("sqlcon");
builder.Services.AddDbContext<EMSDbContext>(options => options.UseSqlServer(constr));

builder.Services.AddScoped<EmployeeService, EmployeeService>();
builder.Services.AddScoped<UserMasterService, UserMasterService>();
builder.Services.AddScoped<GradeMasterService, GradeMasterService>();
builder.Services.AddScoped<DepartmentService, DepartmentService>();
builder.Services.AddScoped<IUserMasterRepo, UserMasterRepo>();
builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
builder.Services.AddScoped<IGradeMasterRepo, GradeMasterRepo>();
builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials());
app.UseAuthorization();

app.MapControllers();

app.Run();
