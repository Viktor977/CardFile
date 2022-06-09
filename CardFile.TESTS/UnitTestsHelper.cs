using CardFile.DAL.Data;
using CardFile.DAL.Entities;
using CardFile.DAL.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardFile.TESTS
{
    public static class UnitTestsHelper
    {
        public static DbContextOptions<CardFileDBContext> GetUnitTestDbOptions()
        {
            var options = new DbContextOptionsBuilder<CardFileDBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using (var context = new CardFileDBContext(options))
            {
                SeedData(context);
            }

            return options;
        }
        
        public static void SeedData(CardFileDBContext context)
        {
            var userOne = new User { Id = 1, FirstName = "FNameOne", LastName = "LNameOne", Role = Roles.Registered };
            var userTwo = new User { Id =2, FirstName = "FNameTwo", LastName = "LNameTwo", Role = Roles.Registered };
            var userThree = new User { Id = 3, FirstName = "FNameThree", LastName = "LNameThree", Role = Roles.Registered };
            context.Users.AddRange(userOne);
            context.Users.AddRange(userTwo);
            context.Users.AddRange(userThree);

            

            context.SaveChanges();
        }
    }
}
