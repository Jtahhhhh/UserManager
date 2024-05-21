using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
//Add cors
builder.Services.AddCors(c=> 
        {
         c.AddPolicy("AllowOrigin", option => option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); 
        });
//Add Json serializer
builder.Services.AddControllersWithViews().AddNewtonsoftJson(option =>
    option.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore)
.AddNewtonsoftJson(option=>option.SerializerSettings.ContractResolver= new DefaultContractResolver());
    

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Enable cors
app.UseCors(option => option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
//Use static 
app.UseAuthorization();

app.MapControllers();

app.Run();
