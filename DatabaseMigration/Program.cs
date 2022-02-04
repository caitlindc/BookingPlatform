using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using BookingPlatform.Infrastructure.Persistence;
using System;
using System.IO;
using BookingPlatform.API;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Applying migrations");

        var webHost = new WebHostBuilder()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<Startup>()
            .Build();

        using (var context = (ApplicationDbContext)webHost.Services.GetService(typeof(ApplicationDbContext)))
        {
            context.Database.Migrate();
        }

        Console.WriteLine("Done");
    }
}