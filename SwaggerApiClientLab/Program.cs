using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Threading.Tasks;
//using MyClientNamespace;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));
        app.MapControllers();
       
       Task.Run(() => app.RunAsync());
        
        await Task.Delay(3000); // Wait for the server to start
        await new ClientGenerator().GenerateClient();

       

       var httpClient = new HttpClient();
       //var client = new CustomApiClient("http://localhost:5000",httpClient);

       //var user = await client.GetUserAsync(1);
       //Console.WriteLine($"User: {user.Name}, Email: {user.Email}");

       app.Run();
    }
}
