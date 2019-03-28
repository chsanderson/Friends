//Christopher Sanderson
//Friends
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;

namespace Friends.Models
{
    public static class SeedData
    {
        //this adds records to the friends database if there is no records in the database
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            //this establishes a connection with the friends database using ApplicationDBContent
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            //this checks to see if there is no records in the databse
            if (!context.friends.Any())
            {
                //this creates 3 records for the friends database by setting the firstname and lastname of those records and saving the changes of the database context
                context.friends.AddRange
                (
                    new Friend
                    {
                        FirstName = "First",
                        LastName = "Friend"
                    },
                    new Friend
                    {
                        FirstName = "Many",
                        LastName = "Friends"
                    },
                    new Friend
                    {
                        FirstName = "Last",
                        LastName = "Friend"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
