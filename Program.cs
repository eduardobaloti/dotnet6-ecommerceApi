using Microsoft.EntityFrameworkCore;
using udemy_dotnet.Controller.Categories;
using udemy_dotnet.services.Data;

var builder = WebApplication.CreateBuilder(args);
var mysqldb = builder.Configuration.GetConnectionString("Default");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseMySql(mysqldb,ServerVersion.AutoDetect(mysqldb)));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapMethods(CategoryPost.Template, CategoryPost.Methods, CategoryPost.Handle);
app.MapMethods(CategoryGetAll.Template, CategoryGetAll.Methods, CategoryGetAll.Handle);
app.MapMethods(CategoryPut.Template, CategoryPut.Methods, CategoryPut.Handle);
app.MapMethods(CategoryDelete.Template, CategoryDelete.Methods, CategoryDelete.Handle);



app.Run();

