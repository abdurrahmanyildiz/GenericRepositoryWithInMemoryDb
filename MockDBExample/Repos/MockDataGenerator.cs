using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MockDBExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockDBExample.Repos
{
    public class MockDataGenerator
    {
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            using (var context = scope.ServiceProvider.GetRequiredService<MockDbContext>())
            {
                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User
                        {
                            UID = Guid.NewGuid().ToString(),
                            Name = "Justin",
                            Lastname = "Timberlake",
                            Username = "just_a_crazy",
                            BirthDate = DateTime.Now
                        },
                        new User
                        {
                            UID = Guid.NewGuid().ToString(),
                            Name = "George",
                            Lastname = "Clooney",
                            Username = "cool_george",
                            BirthDate = DateTime.Now
                        });

                    context.SaveChanges();
                }
            }

        }

    }
}
