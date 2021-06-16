using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Nemesys.Models
{
    public class DbInitializer
    {
        public static void SeedRoles(RoleManager<IdentityRole> roleManager) // create roles
        {
            if (!roleManager.Roles.Any())
            {
                roleManager.CreateAsync(new IdentityRole("Reporter")).Wait();
                roleManager.CreateAsync(new IdentityRole("Investigator")).Wait();
            }
        }

        public static void SeedUsers(UserManager<ApplicationUser> userManager) // crzate 1 investigator and 1 reporter
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
                    userManager.AddToRoleAsync(user, "Reporter").Wait();
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
                    userManager.AddToRoleAsync(admin, "Investigator").Wait();
                }
            }
        }


        public static void SeedData(UserManager<ApplicationUser> userManager, AppDbContext context)
        {
            if (!context.Status.Any())
            {
                context.AddRange
                (
                    new Status()
                    {
                        Name = "Open"
                    },
                    new Status()
                    {
                        Name = "Being investigated"
                    },
                    new Status()
                    {
                        Name = "No action required"
                    },
                    new Status()
                    {
                        Name = "Closed"
                    }
                );
                context.SaveChanges();
            }


            if (!context.TypeOfHazard.Any())
            {
                context.AddRange
                (
                    new TypeOfHazard()
                    {
                        Name = "e.g. unsafe act"
                    },
                    new TypeOfHazard()
                    {
                        Name = "Condition"
                    },
                    new TypeOfHazard()
                    {
                        Name = "Equipment"
                    },
                    new TypeOfHazard()
                    {
                        Name = "Structure"
                    }
                );
                context.SaveChanges();
            }


            if (!context.Reports.Any())
            {
                //Grabbing first one
                var user = userManager.GetUsersInRoleAsync("Reporter").Result.FirstOrDefault();

                context.AddRange
                (
                    new Report()
                    {
                        CreatedDate = DateTime.UtcNow,
                        Date = DateTime.UtcNow,
                        Title = "Water Problem",
                        Description = "There is a water problem in the last toilet of the boys",
                        Location = "Gym",
                        ReporterInformations = user.Email,
                        ImageUrl = "/images/seed1.jpg",
                        Upvotes = 0,
                        //InvestationId = 0,
                        StatusId = 1,
                        TypeOfHazardId = 1,
                        UserId = user.Id
                    },
                    new Report()
                    {
                        CreatedDate = DateTime.UtcNow,
                        Date = DateTime.UtcNow,
                        Title = "Electricity Problem",
                        Description = "There isn't electricity in the teacher local",
                        Location = "Local teacher",
                        ReporterInformations = user.Email,
                        ImageUrl = "/images/seed2.jpg",
                        Upvotes = 2,
                        //InvestationId = 1,
                        StatusId = 4,
                        TypeOfHazardId = 2,
                        UserId = user.Id
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
