using AutoMapper;
using CardFile.BAL.Access;
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
        public static IMapper CreateMapperProfile()
        {
            var myProfile = new AutoMapperProfile();       
            return myProfile.GetMapper();
        }

        public static void SeedData(CardFileDBContext context)
        {
            var userOne = new User { Id = 1, FirstName = "FNameOne", LastName = "LNameOne", Role = Roles.Registered , Email = "userOne@gmail", Password = "@usEr!1" };
            var userTwo = new User { Id =2, FirstName = "FNameTwo", LastName = "LNameTwo", Role = Roles.Registered, Email = "userTwo@gmail", Password = "@usEr!2" };
            var userThree = new User { Id = 3, FirstName = "FNameThree", LastName = "LNameThree", Role = Roles.Registered, Email = "userThree@gmail", Password = "@usEr!3" };
            context.Users.AddRange(userOne);
            context.Users.AddRange(userTwo);
            context.Users.AddRange(userThree);

            var historyOne = new History { Id = 1, ReaderId = 1, TextId = 1, LastAction = new DateTime(2022, 02, 20) };
            var historyTwo = new History { Id = 2, ReaderId = 2, TextId = 2, LastAction = new DateTime(2022, 02, 21) };
            context.Histories.AddRange(historyOne);
            context.Histories.AddRange(historyTwo);

            var reactionOne = new Reaction { Id = 1,TextId=1, Assessment = Assessments.Like, UserId = 1, Comment = "amazing!!!" };
            var reactionTwo = new Reaction { Id = 2,TextId=1, Assessment = Assessments.Like, UserId = 2, Comment = "cool!" };
            var reactionThree = new Reaction { Id = 3,TextId=1, Assessment = Assessments.Dislike, UserId = 3, Comment = " " };
            context.Reactions.AddRange(reactionOne);
            context.Reactions.AddRange(reactionTwo);
            context.Reactions.AddRange(reactionThree);

            var textOne = new TextMaterial { Id = 1, Allows = Allows.Allowed, DatePublish = new DateTime(2020, 12, 21), Author = "Doe A." ,Title="Test1",Article="some text1"};
            var textTwo = new TextMaterial { Id = 2, Allows = Allows.Accepted, DatePublish = new DateTime(2020, 12, 22), Author = "Doe B." ,Title="Test2",Article="some text2"};
            var textThree = new TextMaterial { Id = 3, Allows = Allows.Rejected, DatePublish = new DateTime(2020, 12, 23), Author = "Doe C.", Title = "Test3", Article ="some text3" };
            context.Materials.AddRange(textOne);
            context.Materials.AddRange(textTwo);
            context.Materials.AddRange(textThree);


            context.SaveChanges();
        }
       
    }
}
