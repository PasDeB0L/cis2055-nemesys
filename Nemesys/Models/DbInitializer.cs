using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.Models
{
    public class DbInitializer
    {
        public static void SeedData( AppDbContext context) //UserManager<ApplicationUser> userManager,
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
                // var user = userManager.GetUsersInRoleAsync("User").Result.FirstOrDefault();

                context.AddRange
                (
                    new Report()
                    {
                        Id = 1,
                        Upvotes = 3,
                        TypeOfHasardId = 1,
                        DetailsOnTheReporter = "IDuser1, charlessaison@hotmail.fr, 0607783252",
                        ImageUrl = "/images/seed1.jpg",
                        StatusId = 1,
                        Description = "water problem",
                        Location = "Toilet",
                        DateOfReport = new DateTime(2021,9,12),
                        DateAndTime = new DateTime(2021, 9, 6),
                        Investigation = false,
                        UserId = 1
                    },
                    new Report()
                    {
                        Id = 2,
                        Upvotes = 0,
                        TypeOfHasardId = 2,
                        DetailsOnTheReporter = "IDuser1, charlessaison@hotmail.fr, 0607783252",
                        ImageUrl = "/images/seed2.jpg",
                        StatusId = 2,
                        Description = "ELECTRICAL PB",
                        Location = "GYM",
                        DateOfReport = new DateTime(2021, 7, 23),
                        DateAndTime = new DateTime(2021, 7,22),
                        Investigation = false,
                        UserId = 1
                    }
                ); ; ;
                context.SaveChanges();
            
            }
            
        }
        }
}
