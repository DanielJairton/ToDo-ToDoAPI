using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

using Microsoft.AspNetCore.Cors;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Database na memória
// builder.Services.AddDbContext<TodoContext>(opt =>
//     opt.UseInMemoryDatabase("TodoList"));
//

//Conexão SQLServer
builder.Services.AddDbContext<TodoContext>(
    x => x.UseSqlServer(builder.Configuration.GetConnectionString("conexaoCasa")));
//

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "_allowAll",
        policy  =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});
//

var app = builder.Build();

//CORS
/*
builder.Services.AddCors(app.useCors(options => 
{
    options.AllowAnyHead();
    options.AllowAnyMethod();
    options.AllowAnyOrigin();
}));
*/
/*
var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy  =>
        {
            policy.WithOrigins("http://example.com",
                                "http://www.contoso.com");
        });
});

app.UseCors(MyAllowSpecificOrigins);
*/
/*
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy",
    builder =>
    {
        builder.WithOrigins("*")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});
app.UseCors("MyPolicy");
*/
//

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Cors
/*
builder.Services.AddCors(app.useCors(options => 
{
    options.AllowAnyHead();
    options.AllowAnyMethod();
    options.AllowAnyOrigin();
}));
*/
/*
var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy  =>
        {
            policy.WithOrigins("http://example.com",
                                "http://www.contoso.com");
        });
});

app.UseCors(MyAllowSpecificOrigins);
*/
/*
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy",
    builder =>
    {
        builder.WithOrigins("*")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});
*/
//app.UseCors("MyPolicy");

/*
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy",
    builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});
app.UseCors("MyPolicy");
*/


//
//Cors
app.UseCors("_allowAll");
//

app.UseAuthorization();

app.MapControllers();

app.Run();