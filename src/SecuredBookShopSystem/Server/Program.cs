using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// => we first need to get the current assembly of our Server project
var assembly = typeof(Program).Assembly.GetName().Name;

// => then we need to add some configurations
builder.Services
    .AddIdentityServer()
    .AddConfigurationStore(
        options =>
        {
            options.ConfigureDbContext = b =>
                b.UseSqlServer(
                        builder.Configuration.GetConnectionString("DefaultConnection"),
                        opt => opt.MigrationsAssembly(assembly)
                );
        }
    )
    .AddOperationalStore(
        options =>
        {
            options.ConfigureDbContext = b =>
                b.UseSqlServer(
                        builder.Configuration.GetConnectionString("DefaultConnection"),
                        opt => opt.MigrationsAssembly(assembly)
                );
        }
    )
    .AddDeveloperSigningCredential();

var app = builder.Build();

app.UseIdentityServer();

app.MapControllers();
app.Run();
