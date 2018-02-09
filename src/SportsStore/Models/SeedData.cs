using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace SportsStore.Models
{     
    /// <summary>
    /// fill db in case that db is empty
    /// </summary>
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.
                GetRequiredService<ApplicationDbContext>();
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product{
                        Name = "Kayak",
                        Description = "А boat for one person",
                        Category = "Watersports",
                        Price = 275m
                    },
                    new Product {
                        Name = "Lifejacket",
                        Description = "Protective and fashionable",
                        Category = "Watersports ",
                        Price = 48.95m
                    },
                    new Product {
                        Name = "Soccer Ball ",
                        Description = "FIFA-approved size and weight",
                        Category = "Soccer",
                        Price = 19.50m
                    },
                    new Product {
                        Name = "Corner Flags ",
                        Description = "Give your playing field а professional touch",
                        Category = "Soccer",
                        Price = 34.95m
                    },
                    new Product {
                        Name = "Stadium",
                        Description = "Flat - packed 35,000- seat stadium ",
                        Category = "Soccer",
                        Price = 79500m
                    },
                    new Product {
                        Name = "Thinking Сар ",
                        Description = "Improve brain efficiency bу 75%",
                        Category = "Chess",
                        Price = 16m
                    },
                    new Product {
                        Name = "Unsteady Chair",
                        Description = "Secretly give your opponent а disadvantage",
                        Category = "Chess",
                        Price = 29.95m
                    },
                    new Product {
                        Name = "Human Chess Board",
                        Description = "А fun game for the family ",
                        Category = "Chess",
                        Price = 75m
                    },
                    new Product {
                        Name = " Bling-Bling King",
                        Description = "Gold-plated, diamond-studded King",
                        Category = "Chess",
                        Price = 1200m
                    }
                    );
                context.SaveChanges();
             }
        }
    }
}
