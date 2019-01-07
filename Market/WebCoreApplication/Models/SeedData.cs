using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace WebCoreApplication.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetRequiredService<AppDbContext>();
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Kayak",
                        Description = "А boat for one person",
                        Category = "Watersports",
                        Price = 275
                    },
                    new Product
                    {
                        Name = " Lifejacket ",
                        Description =
                            "Protect ive and fashionaЫe",
                        Category = "Watersports ",
                        Price = 48.95m
                    },
                    new Product
                    {
                        Name = "Soccer Ball ",
                        Description =
                            "FIFA-approved size and weight",
                        Category = "Soccer",
                        Price = 19.50m
                    },
                    new Product
                    {
                        Name = " Corner Flags ",
                        Description = "Give your pl aying field а professional touch",
                        Category = "Soccer",
                        Price = 34.95m
                    },
                    new Product
                    {
                        Name = " Stadium",
                        Description = " Fl at- packed 35, 000 - seat stadi um ",
                        Category = "Soccer",
                        Price = 79500
                    },
                    new Product
                    {
                        Name = " Thinking С ар ",
                        Description = "Improve brain ef ficien cy Ьу 75%",
                        Category = "Chess",
                        Price = 16
                    },
                    new Product
                    {
                        Name = "Unst eady Chair",
                        Description = "Secr etly give your oppone nt а disadvantage",
                        Category = "Chess",
                        Price = 29.95m
                    },
                    new Product
                    {
                        Name = " Human Chess Board",
                        Description = "А fun game for t he family",
                        Category = "Chess",
                        Price = 75
                    },
                    new Product
                    {

                        Name = "Bling-Bling King",
                        Description = "Gold-plated, diamond-s t udd ed King",
                        Category = "Chess",
                        Price = 1200

                    }
                );
                context.SaveChanges();
            }
        }
    }
}
