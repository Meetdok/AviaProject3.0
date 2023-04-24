using System.Text.Json.Serialization;
using WebProject.Database;

namespace WebProject;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var c = builder.Services.AddControllers();
        c.AddJsonOptions(opt =>
        {
            opt.JsonSerializerOptions.
                ReferenceHandler = ReferenceHandler.Preserve;
        });
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddAuthentication();

        builder.Services.AddSqlServer<user05_1Context>("server=192.168.200.35;user=user05;password=44084;database=user05_1;");

        //server=192.168.200.35;user=user05;password=44084;database=user05_1; (колледж)
        //server=localhost;Initial Catalog=AviaSales;Integrated Security=True (дома)
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
