using BeatPass.Data.Static;
using BeatPass.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BeatPass.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            //Console.WriteLine("seed pokrenut");
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                
                //Location
                if (!context.Locations.Any())
                {
                    context.Locations.AddRange(new List<Location>()
                    {
                        new Location()
                        {
                            Name ="Location 1",
                            Logo="",
                            Description="This is the decsription of the firts Location"
                        },

                        new Location()
                        {
                            Name ="Location 2",
                            Logo="",
                            Description="This is the decsription of the second Location"
                        },

                        new Location()
                        {
                            Name ="Location 3",
                            Logo="",
                            Description="This is the decsription of the third Location"
                        },

                        new Location()
                        {
                            Name ="Location 4",
                            Logo="",
                            Description="This is the decsription of the fourth Location"
                        },

                        new Location()
                        {
                            Name ="Location 5",
                            Logo="",
                            Description="This is the decsription of the fifth Location"
                        }
                    });
                    context.SaveChanges();
                }
                //Artist
                if (!context.Artists.Any())
                {
                    context.Artists.AddRange(new List<Artist>()
                    {
                        new Artist()
                        {
                            FullName="Artist 1",
                            ProfilePictureURL="",
                            Bio="This is the decsription of the firts Artist"
                        },

                        new Artist()
                        {
                            FullName="Artist 2",
                            ProfilePictureURL="",
                            Bio="This is the decsription of the second Artist"
                        },

                        new Artist()
                        {
                            FullName="Artist 3",
                            ProfilePictureURL="",
                            Bio="This is the decsription of the third Artist"
                        },

                        new Artist()
                        {
                            FullName="Artist 4",
                            ProfilePictureURL="",
                            Bio="This is the decsription of the fourth Artist"
                        },

                        new Artist()
                        {
                            FullName="Artist 5",
                            ProfilePictureURL="",
                            Bio="This is the decsription of the fifth Artist"
                        }
                    });
                    context.SaveChanges();
                }
                //Ogranization
                if (!context.Organizations.Any())
                {
                    context.Organizations.AddRange(new List<Organization>()
                    {
                        new Organization()
                        {
                            Name ="Organization 1",
                            Logo="",
                            Description="This is the decsription of the firts Organization"
                        },

                        new Organization()
                        {
                            Name ="Organization 2",
                            Logo="",
                            Description="This is the decsription of the second Organization"
                        },

                        new Organization()
                        {
                            Name ="Organization 3",
                            Logo="",
                            Description="This is the decsription of the third Organization"
                        },

                        new Organization()
                        {
                            Name ="Organization 4",
                            Logo="",
                            Description="This is the decsription of the fourth Organization"
                        },

                        new Organization()
                        {
                            Name ="Organization 5",
                            Logo="",
                            Description="This is the decsription of the fifth Organization"
                        }
                    });
                    context.SaveChanges();
                }
                //Festival
                if (!context.Festivals.Any())
                {
                    context.Festivals.AddRange(new List<Festival>()
                    {
                        new Festival()
                        {
                            Name ="Festival 1",
                            Logo="",
                            Description="This is the decsription of the firts Festival",
                            Price=1,
                            StartDate=DateTime.Now.AddDays(-10),
                            EndDate=DateTime.Now.AddDays(-2),
                            LocationId=1,
                            OrganizationId=1,
                            FestivalCategory= Enums.FestivalCategory.Hardstyle
                        },

                        new Festival()
                        {
                            Name ="Festival 2",
                            Logo="",
                            Description="This is the decsription of the second Festival",
                            Price=1,
                            StartDate=DateTime.Now.AddDays(-10),
                            EndDate=DateTime.Now.AddDays(-2),
                            LocationId=2,
                            OrganizationId=2,
                            FestivalCategory= Enums.FestivalCategory.Hardstyle
                        },

                        new Festival()
                        {
                            Name ="Festival 3",
                            Logo="",
                            Description="This is the decsription of the third Festival",
                            Price=1,
                            StartDate=DateTime.Now.AddDays(-10),
                            EndDate=DateTime.Now.AddDays(-2),
                            LocationId=3,
                            OrganizationId=3,
                            FestivalCategory= Enums.FestivalCategory.Hardstyle
                        },

                        new Festival()
                        {
                            Name ="Festival 4",
                            Logo="",
                            Description="This is the decsription of the fourth Festival",
                            Price=1,
                            StartDate=DateTime.Now.AddDays(-10),
                            EndDate=DateTime.Now.AddDays(-2),
                            LocationId=4,
                            OrganizationId=4,
                            FestivalCategory= Enums.FestivalCategory.Hardstyle
                        },

                        new Festival()
                        {
                            Name ="Festival 5",
                            Logo="",
                            Description="This is the decsription of the fifth Festival",
                            Price=1,
                            StartDate=DateTime.Now.AddDays(-10),
                            EndDate=DateTime.Now.AddDays(-2),
                            LocationId=5,
                            OrganizationId=5,
                            FestivalCategory= Enums.FestivalCategory.Hardstyle
                        }
                    });
                    context.SaveChanges();
                }
                //Artists & Festivals
                if (!context.Artists_Festivals.Any())
                {
                    context.Artists_Festivals.AddRange(new List<Artist_Festival>()
                    {
                        new Artist_Festival()
                        {
                            ArtistId = 1,
                            FestivalId = 1
                        },

                        new Artist_Festival()
                        {
                            ArtistId = 2,
                            FestivalId = 2
                        },

                        new Artist_Festival()
                        {
                            ArtistId = 3,
                            FestivalId = 3
                        },

                        new Artist_Festival()
                        {
                            ArtistId = 4,
                            FestivalId = 4
                        },

                        new Artist_Festival()
                        {
                            ArtistId = 5,
                            FestivalId = 5
                        },
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@beatpass.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@beatpass.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
