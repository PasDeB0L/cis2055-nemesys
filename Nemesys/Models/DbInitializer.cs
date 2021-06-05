﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

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

        public static void SeedData(UserManager<ApplicationUser> userManager, AppDbContext context)
        {

            /*
             * 
             * 
             * 
             * For BloggyDB
             * 
             * 
             * 
             * 
             */



            if (!context.Categories.Any())
            {
                context.AddRange
                (
                    new Category()
                    {
                        Name = "Uncategorised"
                    },
                    new Category()
                    {
                        Name = "Comedy"
                    },
                    new Category()
                    {
                        Name = "News"
                    }
                );
                context.SaveChanges();
            }

            if (!context.BlogPosts.Any())
            {
                //Grabbing first one
                var user = userManager.GetUsersInRoleAsync("User").Result.FirstOrDefault();

                context.AddRange
                (
                    new BlogPost()
                    {
                        Title = "AGA Today",
                        Content = "Today's AGA is characterized by a series of discussions and debates around ...",
                        CreatedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        ImageUrl = "/images/seed1.jpg",
                        CategoryId = 1,
                        UserId = user.Id
                    },
                    new BlogPost()
                    {
                        Title = "Traffic is incredible",
                        Content = "Today's traffic can't be described using words. Only an image can do that ...",
                        CreatedDate = DateTime.UtcNow.AddDays(-1),
                        UpdatedDate = DateTime.UtcNow.AddDays(-1),
                        ImageUrl = "/images/seed2.jpg",
                        CategoryId = 2,
                        UserId = user.Id
                    },
                    new BlogPost()
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
                        Name = "(e.g. unsafe act"
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
                var user = userManager.GetUsersInRoleAsync("User").Result.FirstOrDefault();

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
                        Investation = false,
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
                        Investation = true,
                        StatusId = 4,
                        TypeOfHazardId = 2,
                        UserId = user.Id
                    }

                );
                context.SaveChanges();
            }


            if (!context.Investigations.Any())
            {
                //Grabbing first one
                var user = userManager.GetUsersInRoleAsync("User").Result.FirstOrDefault();

                context.AddRange
                (
                    new Investigation()
                    {
                        DateOfAction = DateTime.UtcNow,
                        Description = "The electrician was there and he fixed the electricity probleme",
                        InvestigatorDetails = user.Email,
                        StatusId = 4,
                        ReportId = 2,
                        UserId = user.Id
                    }
                );
                context.SaveChanges();
            }










            
        }
    }

}
