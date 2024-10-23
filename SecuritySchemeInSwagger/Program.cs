using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("auth", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "auth",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        Description = "A one time Token. Example: Bearer topsecrettokenkeydheeraj1223"

    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
    {

         new OpenApiSecurityScheme
         {
             Reference = new OpenApiReference
             {
                 Id = "auth",
                 Type = ReferenceType.SecurityScheme
             }

         }, new List<string>{ }
    }});
});
   

   





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
