using System;
using System.Linq;
using AspNetCore_Mvc.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AspNetCore_Mvc
{
    public class C03{
        public static void Main_CreateDbIfNotExists(IWebHost host)
        {
            /*Microsoft.Extensions.DependencyInjection*/
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<DBContext>();
                    context.Database.EnsureCreated();
                    
                    
                    // DB has been seeded
                    if (context.Movie.Any())  return;   

                    context.Movie.AddRange(
                        new Movie
                        {
                            Title = "When Harry Met Sally",
                            ReleaseDate = DateTime.Parse("1989-2-12"),
                            Genre = "Romantic Comedy",
                            Rating = "R",
                            Price = 7.99M
                        },

                        new Movie
                        {
                            Title = "Ghostbusters ",
                            ReleaseDate = DateTime.Parse("1984-3-13"),
                            Genre = "Comedy",
                            Rating = "R",
                            Price = 8.99M
                        },

                        new Movie
                        {
                            Title = "Ghostbusters 2",
                            ReleaseDate = DateTime.Parse("1986-2-23"),
                            Genre = "Comedy",
                            Rating = "R",
                            Price = 9.99M
                        },

                        new Movie
                        {
                            Title = "Rio Bravo",
                            ReleaseDate = DateTime.Parse("1959-4-15"),
                            Genre = "Western",
                            Rating = "R",
                            Price = 3.99M
                        }
                    );
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }

        public static void ConfigureServices_IocDBContext(IServiceCollection services,IConfiguration Configuration){
            services.AddDbContext<DBContext>(options=>{
                options.UseSqlite(Configuration.GetConnectionString("DBContext"));
            });
        }
    }

}
