using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://localhost:5001"; // IdentityServer URL
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false // Set to true if you want to validate the audience
        };
    });

builder.Services.AddOcelot();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

await app.UseOcelot();

app.Run();
