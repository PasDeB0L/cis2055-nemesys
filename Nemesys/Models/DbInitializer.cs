using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.Models
{
    public class DbInitializer
    {
        public static void Initialize( AppDbContext context) //UserManager<ApplicationUser> userManager,
        {
            if (!context.Status.Any())
            {
                context.AddRange
                (
                    new Status()
                    {
                        Name = "Uncategorised"
                    },
                    new Status()
                    {
                        Name = "Comedy"
                    },
                    new Status()
                    {
                        Name = "News"
                    }
                );
                context.SaveChanges();
            }

            if (!context.TypeOfHasard.Any())
            {
                context.AddRange
                (
                    new Status()
                    {
                        Name = "Uncategorised"
                    },
                    new Status()
                    {
                        Name = "Comedy"
                    },
                    new Status()
                    {
                        Name = "News"
                    }
                );
                context.SaveChanges();
            }


            if (!context.Reports.Any())
            {
                //Grabbing first one
                var user = userManager.GetUsersInRoleAsync("User").Result.FirstOrDefault();

                context.AddRange
                (
                    new Report()
                    {
                        Title = "AGA Today",
                        Content = "Today's AGA is characterized by a series of discussions and debates around ...",
                        CreatedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        ImageUrl = "/images/seed1.jpg",
                        CategoryId = 1,
                        UserId = user.Id
                    },
                    new Report()
                    {
                        Title = "Traffic is incredible",
                        Content = "Today's traffic can't be described using words. Only an image can do that ...",
                        CreatedDate = DateTime.UtcNow.AddDays(-1),
                        UpdatedDate = DateTime.UtcNow.AddDays(-1),
                        ImageUrl = "/images/seed2.jpg",
                        CategoryId = 2,
                        UserId = user.Id
                    },
                    new Report()
                    {
                        Title = "When is Spring really starting?",
                        Content = "Clouds clouds all around us. I thought spring started already, but ...",
                        CreatedDate = DateTime.UtcNow.AddDays(-2),
                        UpdatedDate = DateTime.UtcNow.AddDays(-2),
                        ImageUrl = "/images/seed3.jpg",
                        CategoryId = 2,
                        UserId = user.Id
                    }
                );
                context.SaveChanges();
            }
        }
        }
}
