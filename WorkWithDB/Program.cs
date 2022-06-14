using CardFile.DAL.Data;
using CardFile.DAL.Entities;
using CardFile.DAL.Enums;
using System;

namespace WorkWithDB
{
   public class Program
    {
        static void Main(string[] args)
        {
             CreateDB();
             AddEntity();
            Console.WriteLine("successes");
        }
        public static void CreateDB()
        {
            using var dbContext = new CardFileDBContext();

            dbContext.Database.EnsureDeleted();

            dbContext.Database.EnsureCreated();
        }
        public static void AddEntity()
        {
            using var dbContext = new CardFileDBContext();

            var user1 = new User()
            {
                FirstName = "David",
                LastName = "Beckham",
                Role = Roles.Registered,
            };
            var user2 = new User()
            {
                FirstName = "Alan",
                LastName = "Walker",
                Role = Roles.Admin
            };
            //------------------------------
            var user3 = new User()
            {
                FirstName = "Tony",
                LastName = "Hawk",
                Role = Roles.Registered,
            };
            var user4 = new User()
            {
                FirstName = "Jassica",
                LastName = "Alba",
                Role = Roles.Registered,
            };
            var user5 = new User()
            {
                FirstName = "Marry",
                LastName = "Carry",
                Role = Roles.Registered,
            };

            //-----------------------------
            var userProfile = new UserProfile()
            {
                Email = "beckham@gmail.com",
                Password = "1111",
                Login = "Player",
                UserId = user1.Id,
                User = user1,
            };
            var adminProfile = new UserProfile()
            {
                Email = "alan@gmail.com",
                Password = "admin",
                Login = "ALAN",
                UserId = user2.Id,
                User = user2
            };

            var userProfile3 = new UserProfile()
            {
                Email = "hawk@gmail.com",
                Password = "1113",
                Login = "Skateboarder",
                UserId = user3.Id,
                User = user3,
            };
            var userProfile4 = new UserProfile()
            {
                Email = "jessica@gmail.com",
                Password = "1114",
                Login = "businesswoman",
                UserId = user4.Id,
                User = user4,
            };
            var userProfile5 = new UserProfile()
            {
                Email = "marry@gmail.com",
                Password = "1115",
                Login = "butywoman",
                UserId = user5.Id,
                User = user5,
            };

            user1.Profile = userProfile;
            user2.Profile = adminProfile;
            user3.Profile = userProfile3;
            user4.Profile = userProfile4;
            user5.Profile = userProfile5;
           

            dbContext.Users.Add(user1);
            dbContext.Users.Add(user2);
            dbContext.Users.Add(user3);
            dbContext.Users.Add(user4);
            dbContext.Users.Add(user5);
            //  dbContext.SaveChanges();
            dbContext.UserProfiles.Add(userProfile);
            dbContext.UserProfiles.Add(adminProfile);
            dbContext.UserProfiles.Add(userProfile3);
            dbContext.UserProfiles.Add(userProfile4);
            dbContext.UserProfiles.Add(userProfile5);


            var text1 = new TextMaterial()
            {
                Title = "Test1",
                Author = user1.LastName,
                DatePublish =new DateTime(2022,01,02),
                Article = "\tLorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia,\n" +
                           " molestiae quas vel sint commodi repudiandae consequuntur voluptatum laborum\n" +
                           " numquam blanditiis harum quisquam eius sed odit fugiat iusto fuga praesentium\n" +
                            "optio, eaque rerum! Provident similique accusantium nemo autem. Veritatis\n" +
                            "obcaecati tenetur iure eius earum ut molestias architecto voluptate aliquam\n" +
                            "nihil, eveniet aliquid culpa officia aut! Impedit sit sunt quaerat, odit\n," +
                            "tenetur error, harum nesciunt ipsum debitis quas aliquid. Reprehenderit,\n" +
                            "quia. Quo neque error repudiandae fuga? Ipsa laudantium molestias eos\n" +
                            "sapiente officiis modi at sunt excepturi expedita sint? Sed quibusdam\n" +
                            "recusandae alias error harum maxime adipisci amet laborum. Perspiciatis\n " +
                           " minima nesciunt dolorem! Officiis iure rerum voluptates a cumque velit\n" +
                            "quibusdam sed amet tempora. Sit laborum ab, eius fugit doloribus tenetur\n" +
                            "fugiat, temporibus enim commodi iusto libero magni deleniti quod quam\n " +
                            "consequuntur! Commodi minima excepturi repudiandae velit hic maxime\n" +
                            "doloremque. Quaerat provident commodi consectetur veniam similique ad-\n " +
                           " earum omnis ipsum saepe, voluptas, hic voluptates pariatur est explicabo\n" +
                           " fugiat, dolorum eligendi quam cupiditate excepturi mollitia maiores labore\n" +
                            "suscipit quas? Nulla, placeat. Voluptatem quaerat non architecto ab laudantium\n" +
                            "modi minima sunt esse temporibus sint culpa, recusandae aliquam numquam \n" +
                            "totam ratione voluptas quod exercitationem fuga. Possimus quis earum veniam \n" +
                            "quasi aliquam eligendi, placeat qui corporis!",


                Allows = Allows.Allowed,

            };

            var text2 = new TextMaterial()
            {
                Title = "Test2",
                Author = user2.LastName,
                DatePublish = new DateTime(2021,10,20),
                Article = "\tLorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia,\n" +
                          " molestiae quas vel sint commodi repudiandae consequuntur voluptatum laborum\n" +
                          " numquam blanditiis harum quisquam eius sed odit fugiat iusto fuga praesentium\n" +
                           "optio, eaque rerum! Provident similique accusantium nemo autem. Veritatis\n" +
                           "obcaecati tenetur iure eius earum ut molestias architecto voluptate aliquam\n" +
                           "nihil, eveniet aliquid culpa officia aut! Impedit sit sunt quaerat, odit\n," +
                           "tenetur error, harum nesciunt ipsum debitis quas aliquid. Reprehenderit,\n" +
                           "quia. Quo neque error repudiandae fuga? Ipsa laudantium molestias eos\n" +
                           "sapiente officiis modi at sunt excepturi expedita sint? Sed quibusdam\n" +
                           "recusandae alias error harum maxime adipisci amet laborum. Perspiciatis\n " +
                          " minima nesciunt dolorem! Officiis iure rerum voluptates a cumque velit\n" +
                           "quibusdam sed amet tempora. Sit laborum ab, eius fugit doloribus tenetur\n" +
                           "fugiat, temporibus enim commodi iusto libero magni deleniti quod quam\n " +
                           "consequuntur! Commodi minima excepturi repudiandae velit hic maxime\n" +
                           "doloremque. Quaerat provident commodi consectetur veniam similique ad-\n " +
                          " earum omnis ipsum saepe, voluptas, hic voluptates pariatur est explicabo\n" +
                          " fugiat, dolorum eligendi quam cupiditate excepturi mollitia maiores labore\n" +
                           "suscipit quas? Nulla, placeat. Voluptatem quaerat non architecto ab laudantium\n" +
                           "modi minima sunt esse temporibus sint culpa, recusandae aliquam numquam \n" +
                           "totam ratione voluptas quod exercitationem fuga. Possimus quis earum veniam \n" +
                           "quasi aliquam eligendi, placeat qui corporis!",


                Allows = Allows.Allowed,

            };
            var text3 = new TextMaterial()
            {
                Title = "Test3",
                Author = user3.LastName,
                DatePublish = new DateTime(2021,08,22),
                Article = "\tLorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia,\n" +
                          " molestiae quas vel sint commodi repudiandae consequuntur voluptatum laborum\n" +
                          " numquam blanditiis harum quisquam eius sed odit fugiat iusto fuga praesentium\n" +
                           "optio, eaque rerum! Provident similique accusantium nemo autem. Veritatis\n" +
                           "obcaecati tenetur iure eius earum ut molestias architecto voluptate aliquam\n" +
                           "nihil, eveniet aliquid culpa officia aut! Impedit sit sunt quaerat, odit\n," +
                           "tenetur error, harum nesciunt ipsum debitis quas aliquid. Reprehenderit,\n" +
                           "quia. Quo neque error repudiandae fuga? Ipsa laudantium molestias eos\n" +
                           "sapiente officiis modi at sunt excepturi expedita sint? Sed quibusdam\n" +
                           "recusandae alias error harum maxime adipisci amet laborum. Perspiciatis\n " +
                          " minima nesciunt dolorem! Officiis iure rerum voluptates a cumque velit\n" +
                           "quibusdam sed amet tempora. Sit laborum ab, eius fugit doloribus tenetur\n" +
                           "fugiat, temporibus enim commodi iusto libero magni deleniti quod quam\n " +
                           "consequuntur! Commodi minima excepturi repudiandae velit hic maxime\n" +
                           "doloremque. Quaerat provident commodi consectetur veniam similique ad-\n " +
                          " earum omnis ipsum saepe, voluptas, hic voluptates pariatur est explicabo\n" +
                          " fugiat, dolorum eligendi quam cupiditate excepturi mollitia maiores labore\n" +
                           "suscipit quas? Nulla, placeat. Voluptatem quaerat non architecto ab laudantium\n" +
                           "modi minima sunt esse temporibus sint culpa, recusandae aliquam numquam \n" +
                           "totam ratione voluptas quod exercitationem fuga. Possimus quis earum veniam \n" +
                           "quasi aliquam eligendi, placeat qui corporis!",


                Allows = Allows.Allowed,

            };
            var text4 = new TextMaterial()
            {
                Title = "Test4",
                Author = user4.LastName,
                DatePublish = new DateTime(2020,12,29),
                Article = "\tLorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia,\n" +
                          " molestiae quas vel sint commodi repudiandae consequuntur voluptatum laborum\n" +
                          " numquam blanditiis harum quisquam eius sed odit fugiat iusto fuga praesentium\n" +
                           "optio, eaque rerum! Provident similique accusantium nemo autem. Veritatis\n" +
                           "obcaecati tenetur iure eius earum ut molestias architecto voluptate aliquam\n" +
                           "nihil, eveniet aliquid culpa officia aut! Impedit sit sunt quaerat, odit\n," +
                           "tenetur error, harum nesciunt ipsum debitis quas aliquid. Reprehenderit,\n" +
                           "quia. Quo neque error repudiandae fuga? Ipsa laudantium molestias eos\n" +
                           "sapiente officiis modi at sunt excepturi expedita sint? Sed quibusdam\n" +
                           "recusandae alias error harum maxime adipisci amet laborum. Perspiciatis\n " +
                          " minima nesciunt dolorem! Officiis iure rerum voluptates a cumque velit\n" +
                           "quibusdam sed amet tempora. Sit laborum ab, eius fugit doloribus tenetur\n" +
                           "fugiat, temporibus enim commodi iusto libero magni deleniti quod quam\n " +
                           "consequuntur! Commodi minima excepturi repudiandae velit hic maxime\n" +
                           "doloremque. Quaerat provident commodi consectetur veniam similique ad-\n " +
                          " earum omnis ipsum saepe, voluptas, hic voluptates pariatur est explicabo\n" +
                          " fugiat, dolorum eligendi quam cupiditate excepturi mollitia maiores labore\n" +
                           "suscipit quas? Nulla, placeat. Voluptatem quaerat non architecto ab laudantium\n" +
                           "modi minima sunt esse temporibus sint culpa, recusandae aliquam numquam \n" +
                           "totam ratione voluptas quod exercitationem fuga. Possimus quis earum veniam \n" +
                           "quasi aliquam eligendi, placeat qui corporis!",


                Allows = Allows.Allowed,

            };
            var text5 = new TextMaterial()
            {
                Title = "Test5",
                Author = user5.LastName,
                DatePublish =new  DateTime(2021,12,12),
                Article = "\tLorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia,\n" +
                          " molestiae quas vel sint commodi repudiandae consequuntur voluptatum laborum\n" +
                          " numquam blanditiis harum quisquam eius sed odit fugiat iusto fuga praesentium\n" +
                           "optio, eaque rerum! Provident similique accusantium nemo autem. Veritatis\n" +
                           "obcaecati tenetur iure eius earum ut molestias architecto voluptate aliquam\n" +
                           "nihil, eveniet aliquid culpa officia aut! Impedit sit sunt quaerat, odit\n," +
                           "tenetur error, harum nesciunt ipsum debitis quas aliquid. Reprehenderit,\n" +
                           "quia. Quo neque error repudiandae fuga? Ipsa laudantium molestias eos\n" +
                           "sapiente officiis modi at sunt excepturi expedita sint? Sed quibusdam\n" +
                           "recusandae alias error harum maxime adipisci amet laborum. Perspiciatis\n " +
                          " minima nesciunt dolorem! Officiis iure rerum voluptates a cumque velit\n" +
                           "quibusdam sed amet tempora. Sit laborum ab, eius fugit doloribus tenetur\n" +
                           "fugiat, temporibus enim commodi iusto libero magni deleniti quod quam\n " +
                           "consequuntur! Commodi minima excepturi repudiandae velit hic maxime\n" +
                           "doloremque. Quaerat provident commodi consectetur veniam similique ad-\n " +
                          " earum omnis ipsum saepe, voluptas, hic voluptates pariatur est explicabo\n" +
                          " fugiat, dolorum eligendi quam cupiditate excepturi mollitia maiores labore\n" +
                           "suscipit quas? Nulla, placeat. Voluptatem quaerat non architecto ab laudantium\n" +
                           "modi minima sunt esse temporibus sint culpa, recusandae aliquam numquam \n" +
                           "totam ratione voluptas quod exercitationem fuga. Possimus quis earum veniam \n" +
                           "quasi aliquam eligendi, placeat qui corporis!",


                Allows = Allows.Allowed,

            };
            var text6 = new TextMaterial()
            {
                Title = "Test6",
                Author = user1.LastName,
                DatePublish = new DateTime(2022,01,20),
                Article = "\tLorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia,\n" +
                          " molestiae quas vel sint commodi repudiandae consequuntur voluptatum laborum\n" +
                          " numquam blanditiis harum quisquam eius sed odit fugiat iusto fuga praesentium\n" +
                           "optio, eaque rerum! Provident similique accusantium nemo autem. Veritatis\n" +
                           "obcaecati tenetur iure eius earum ut molestias architecto voluptate aliquam\n" +
                           "nihil, eveniet aliquid culpa officia aut! Impedit sit sunt quaerat, odit\n," +
                           "tenetur error, harum nesciunt ipsum debitis quas aliquid. Reprehenderit,\n" +
                           "quia. Quo neque error repudiandae fuga? Ipsa laudantium molestias eos\n" +
                           "sapiente officiis modi at sunt excepturi expedita sint? Sed quibusdam\n" +
                           "recusandae alias error harum maxime adipisci amet laborum. Perspiciatis\n " +
                          " minima nesciunt dolorem! Officiis iure rerum voluptates a cumque velit\n" +
                           "quibusdam sed amet tempora. Sit laborum ab, eius fugit doloribus tenetur\n" +
                           "fugiat, temporibus enim commodi iusto libero magni deleniti quod quam\n " +
                           "consequuntur! Commodi minima excepturi repudiandae velit hic maxime\n" +
                           "doloremque. Quaerat provident commodi consectetur veniam similique ad-\n " +
                          " earum omnis ipsum saepe, voluptas, hic voluptates pariatur est explicabo\n" +
                          " fugiat, dolorum eligendi quam cupiditate excepturi mollitia maiores labore\n" +
                           "suscipit quas? Nulla, placeat. Voluptatem quaerat non architecto ab laudantium\n" +
                           "modi minima sunt esse temporibus sint culpa, recusandae aliquam numquam \n" +
                           "totam ratione voluptas quod exercitationem fuga. Possimus quis earum veniam \n" +
                           "quasi aliquam eligendi, placeat qui corporis!",


                Allows = Allows.Allowed,

            };
            var text7 = new TextMaterial()
            {
                Title = "Test7",
                Author = user2.LastName,
                DatePublish =new DateTime(2020,12,31),
                Article = "\tLorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia,\n" +
                          " molestiae quas vel sint commodi repudiandae consequuntur voluptatum laborum\n" +
                          " numquam blanditiis harum quisquam eius sed odit fugiat iusto fuga praesentium\n" +
                           "optio, eaque rerum! Provident similique accusantium nemo autem. Veritatis\n" +
                           "obcaecati tenetur iure eius earum ut molestias architecto voluptate aliquam\n" +
                           "nihil, eveniet aliquid culpa officia aut! Impedit sit sunt quaerat, odit\n," +
                           "tenetur error, harum nesciunt ipsum debitis quas aliquid. Reprehenderit,\n" +
                           "quia. Quo neque error repudiandae fuga? Ipsa laudantium molestias eos\n" +
                           "sapiente officiis modi at sunt excepturi expedita sint? Sed quibusdam\n" +
                           "recusandae alias error harum maxime adipisci amet laborum. Perspiciatis\n " +
                          " minima nesciunt dolorem! Officiis iure rerum voluptates a cumque velit\n" +
                           "quibusdam sed amet tempora. Sit laborum ab, eius fugit doloribus tenetur\n" +
                           "fugiat, temporibus enim commodi iusto libero magni deleniti quod quam\n " +
                           "consequuntur! Commodi minima excepturi repudiandae velit hic maxime\n" +
                           "doloremque. Quaerat provident commodi consectetur veniam similique ad-\n " +
                          " earum omnis ipsum saepe, voluptas, hic voluptates pariatur est explicabo\n" +
                          " fugiat, dolorum eligendi quam cupiditate excepturi mollitia maiores labore\n" +
                           "suscipit quas? Nulla, placeat. Voluptatem quaerat non architecto ab laudantium\n" +
                           "modi minima sunt esse temporibus sint culpa, recusandae aliquam numquam \n" +
                           "totam ratione voluptas quod exercitationem fuga. Possimus quis earum veniam \n" +
                           "quasi aliquam eligendi, placeat qui corporis!",


                Allows = Allows.Rejected,

            };
            var text8 = new TextMaterial()
            {
                Title = "Test8",
                Author = user3.LastName,
                DatePublish = DateTime.Now,
                Article = "\tLorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia,\n" +
                          " molestiae quas vel sint commodi repudiandae consequuntur voluptatum laborum\n" +
                          " numquam blanditiis harum quisquam eius sed odit fugiat iusto fuga praesentium\n" +
                           "optio, eaque rerum! Provident similique accusantium nemo autem. Veritatis\n" +
                           "obcaecati tenetur iure eius earum ut molestias architecto voluptate aliquam\n" +
                           "nihil, eveniet aliquid culpa officia aut! Impedit sit sunt quaerat, odit\n," +
                           "tenetur error, harum nesciunt ipsum debitis quas aliquid. Reprehenderit,\n" +
                           "quia. Quo neque error repudiandae fuga? Ipsa laudantium molestias eos\n" +
                           "sapiente officiis modi at sunt excepturi expedita sint? Sed quibusdam\n" +
                           "recusandae alias error harum maxime adipisci amet laborum. Perspiciatis\n " +
                          " minima nesciunt dolorem! Officiis iure rerum voluptates a cumque velit\n" +
                           "quibusdam sed amet tempora. Sit laborum ab, eius fugit doloribus tenetur\n" +
                           "fugiat, temporibus enim commodi iusto libero magni deleniti quod quam\n " +
                           "consequuntur! Commodi minima excepturi repudiandae velit hic maxime\n" +
                           "doloremque. Quaerat provident commodi consectetur veniam similique ad-\n " +
                          " earum omnis ipsum saepe, voluptas, hic voluptates pariatur est explicabo\n" +
                          " fugiat, dolorum eligendi quam cupiditate excepturi mollitia maiores labore\n" +
                           "suscipit quas? Nulla, placeat. Voluptatem quaerat non architecto ab laudantium\n" +
                           "modi minima sunt esse temporibus sint culpa, recusandae aliquam numquam \n" +
                           "totam ratione voluptas quod exercitationem fuga. Possimus quis earum veniam \n" +
                           "quasi aliquam eligendi, placeat qui corporis!",


                Allows = Allows.Accepted,

            };

            var history = new History()
            {
                LastAction = new DateTime(2022,05,02),
                Material = text1,
                ReaderId = user1.Id,
                TextId = text1.Id,
                User = user1

            };
            var history2 = new History()
            {
                LastAction = new DateTime(2022, 04, 20),
                Material = text2,
                ReaderId = user2.Id,
                TextId = text2.Id,
                User = user2

            };
            var history3 = new History()
            {
                LastAction = new DateTime(2022, 05, 20),
                Material = text3,
                ReaderId = user3.Id,
                TextId = text3.Id,
                User = user3

            };
            var history4 = new History()
            {
                LastAction = new DateTime(2022, 05, 29),
                Material = text4,
                ReaderId = user4.Id,
                TextId = text4.Id,
                User = user4

            };
            var history5 = new History()
            {
                LastAction = new DateTime(2022, 02, 20),
                Material = text5,
                ReaderId = user5.Id,
                TextId = text5.Id,
                User = user5

            };
            var history6 = new History()
            {
                LastAction = new DateTime(2022, 05, 20),
                Material = text6,
                ReaderId = user1.Id,
                TextId = text6.Id,
                User = user1

            };
            var history7 = new History()
            {
                LastAction = new DateTime(2022,06,10),
                Material = text7,
                ReaderId = user2.Id,
                TextId = text7.Id,
                User = user2

            };
            var history8 = new History()
            {
                LastAction = DateTime.Now,
                Material = text8,
                ReaderId = user3.Id,
                TextId = text8.Id,
                User = user3

            };
         


            var reaction11 = new Reaction()
            {
                UserId = user1.Id,
                Text = text1,
                Comment = "with out comments :)",
                Assessment = Assessments.Like
            };
           // reaction11.UserId = user2.Id;

            var reaction12 = new Reaction()
            {
                UserId = user2.Id,
                Text = text1,
                Comment = "without comments :(",
                Assessment = Assessments.Dislike
            };
          //  reaction12.UserId = user1.Id;

            var reaction13 = new Reaction()
            {
                UserId = user4.Id,
                Text = text1,
                Comment = "cool!!!",
                Assessment = Assessments.Like
            };
           // reaction13.UserId = user4.Id;
            var reaction14 = new Reaction()
            {
                UserId = user5.Id,
                Text = text1,
              
                Assessment = Assessments.Dislike
            };
            //  reaction14.UserId = user5.Id;
            //text1.Reactions.Add(reaction11);
            //text1.Reactions.Add(reaction12);
            //text1.Reactions.Add(reaction13);
            //text1.Reactions.Add(reaction14);

            dbContext.Reactions.Add(reaction11);
            dbContext.Reactions.Add(reaction12);
            dbContext.Reactions.Add(reaction13);
            dbContext.Reactions.Add(reaction14);


            dbContext.Materials.Add(text1);
            dbContext.Materials.Add(text2);
            dbContext.Materials.Add(text3);
            dbContext.Materials.Add(text4);
            dbContext.Materials.Add(text5);
            dbContext.Materials.Add(text6);
            dbContext.Materials.Add(text7);
            dbContext.Materials.Add(text8);


            dbContext.Histories.Add(history);
            dbContext.Histories.Add(history2);
            dbContext.Histories.Add(history3);
            dbContext.Histories.Add(history4);
            dbContext.Histories.Add(history5);
            dbContext.Histories.Add(history6);
            dbContext.Histories.Add(history7);
            dbContext.Histories.Add(history8);

            dbContext.SaveChanges();

        }
    }
}

