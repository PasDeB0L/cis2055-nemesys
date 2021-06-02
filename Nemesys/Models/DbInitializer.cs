using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.Models
{
    public class DbInitializer
    {

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                roleManager.CreateAsync(new IdentityRole("User")).Wait();
                roleManager.CreateAsync(new IdentityRole("Administrator")).Wait();
            }
        }

        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new ApplicationUser()
                {
                    Email = "testuser@testmail.com",
                    NormalizedEmail = "TESTUSER@TESTMAIL.COM",
                    UserName = "testuser@testmail.com",
                    NormalizedUserName = "TESTUSER@TESTMAIL.COM",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D") //to track important profile updates (e.g. password change)
                };

                //Add to store
                IdentityResult result = userManager.CreateAsync(user, "Bl0ggyRules!").Result;
                if (result.Succeeded)
                {
                    //Add to role
                    userManager.AddToRoleAsync(user, "User").Wait();
                }


                var admin = new ApplicationUser()
                {
                    Email = "testadmin@testmail.com",
                    NormalizedEmail = "TESTADMIN@TESTMAIL.COM",
                    UserName = "testadmin@testmail.com",
                    NormalizedUserName = "TESTADMIN@TESTMAIL.COM",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D") //to track important profile updates (e.g. password change)
                };

                //Add to store
                result = userManager.CreateAsync(admin, "Bl0ggyRules!").Result;
                if (result.Succeeded)
                {
                    //Add to role
                    userManager.AddToRoleAsync(admin, "Administrator").Wait();
                }
            }
        }


        public static void SeedData(UserManager<ApplicationUser> userManager, AppDbContext context) //UserManager<ApplicationUser> userManager,
        {
            
            if (!context.Status.Any())
            {
                
                context.AddRange
                (
                    new Status()
                    {
                        Name = "open"
                    },
                    new Status()
                    {
                        Name = "closed"
                    },
                    new Status()
                    {
                        Name = "being investigated"
                    },
                    new Status()
                    {
                        Name = "no action required"
                    }
                );
                context.SaveChanges();
            }
            
            if (!context.TypeOfHasard.Any())
            {
                
                context.AddRange
                (
                    new TypeOfHasard()
                    {
                        Name = "e.g. unsafe act"
                    },
                    new TypeOfHasard()
                    {
                        Name = "condition"
                    },
                    new TypeOfHasard()
                    {
                        Name = "equipment"
                    },
                    new TypeOfHasard()
                    {
                        Name = "structure"
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
                        Upvotes = 3,
                        TypeOfHasardId = 1,
                        DetailsOnTheReporter = "IDuser1, charlessaison@hotmail.fr, 0607783252",
                        StatusId = 1,
                        ImageUrl = "/images/seed1.jpg",
                        Description = "water problem",
                        Location = "Toilet",
                        DateOfReport = DateTime.UtcNow,
                        DateAndTime = DateTime.UtcNow,
                        Investigation = false,
                        UserId = user.Id
                    },
                    new Report()
                    {
                        Upvotes = 0,
                        TypeOfHasardId = 2,
                        DetailsOnTheReporter = "IDuser1, charlessaison@hotmail.fr, 0607783252",
                        ImageUrl = "/images/seed2.jpg",
                        StatusId = 2,
                        Description = "ELECTRICAL PB",
                        Location = "GYM",
                        DateOfReport = DateTime.UtcNow,
                        DateAndTime = DateTime.UtcNow,
                        Investigation = false,
                        UserId = user.Id
                    }
                ); ; ;
                context.SaveChanges();
            }
        }
    }
}
