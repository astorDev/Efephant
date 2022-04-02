using Efephant.Data;

using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public class Test
{
    protected WebApplicationFactory Factory { get; } =  new();
    protected Client Client { get;  }

    protected Test()
    {
        Client = new(Factory.CreateClient());
    }
    
    public class WebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services => 
            {
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<Context>));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                var guid = Guid.NewGuid().ToString();
                services.AddDbContext<Context>(o => o.UseInMemoryDatabase(guid));
            });
        }
    }
}