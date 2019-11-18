namespace CloudRunSampleAPI
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            string port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
            string url = string.Concat("http://0.0.0.0:", port);

            CreateWebHostBuilder(args, url).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args, string url) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls(url);
    }
}
