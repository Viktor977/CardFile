using CardFile.DAL.Data;
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

        }
    }
}
