using Microsoft.EntityFrameworkCore;
using ProjetPFE.Server.Data;
using ProjetPFE.Server.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("tarekconnection") ?? throw new InvalidOperationException("Connection string not found.");
//the coockie name from appsettings
var thecoockiename = builder.Configuration.GetValue<string>("Thecoockiename");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddAuthentication(thecoockiename).AddCookie(thecoockiename , option => 
{
    option.Cookie.Name = thecoockiename;
    //ki tadir [autherize] anotation fi kach enpoint tsema yachof bali lazem tkon autherized bi coockie wa ida marakch 
    //yaba3tik li hadi path te3 login endpoint
    option.LoginPath = "/api/Authentificate/login";
    //hadi bach tab3to lil endpoit li li 7atkon fiha paga ma9tob fiha acces denied 
    option.AccessDeniedPath = "/";
    //hadi bach el coockie tab9a valide li 10 sawaya3 sinon ki yakhlaso lazem ya3awed ylogi in
    option.ExpireTimeSpan = TimeSpan.FromHours(10);
});

builder.Services.AddAuthorization(option =>
{
    //hadi bach ki nakhadmo les pages te3 el admin dir fo9 les endpoint te3 el admin
    //hadi anotation [autherize(Policy = "AdminPageOnly")] haka ta3ref 3afsa wasimha authorization middle ware bali lazem 
    //ya7a9a hadi el policy bach ya9der yadkhol lil paga
    option.AddPolicy("AdminPageOnly", policy => policy.RequireClaim("role", "admin"));
    //hadi lil user 
    option.AddPolicy("UserPageOnly", policy => policy.RequireClaim("role", "user"));
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("reactfrontPolicy", Policybuilder =>
    {
        Policybuilder.WithOrigins("https://localhost:5173")
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDistributedSqlServerCache(options =>
{
    options.ConnectionString = connectionString;
    options.SchemaName = "dbo";
    options.TableName = "SessionCache";
});
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
});

var app = builder.Build();
app.UseSession();
app.UseDefaultFiles();
app.UseStaticFiles();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");
app.UseCors("reactfrontPolicy");
app.Run();
