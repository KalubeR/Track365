using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Track365.Data;
using Track365.Models;

namespace Track365.Tests
{
    public class DatabaseTests
    {
        [Fact]
        public async void TestIfUserIsSuccessfulyStoreInDB()
        {
            var userName = "test";
            var email = "test@test.com";
            var password = "test";
            var user = new User(userName, email);

            var options = new DbContextOptionsBuilder<TrackDbContext>().UseInMemoryDatabase(databaseName: "Track365").Options;
            using (var context = new TrackDbContext(options))
            {
                context.Users.Add(user);
                context.Users.Add(new User { Id = "213", UserName = "test", Email = "test"});
                context.SaveChanges();
            }
            using (var context = new TrackDbContext(options))
            {
                var users = context.Users.ToList();

                Assert.Equal(2, users.Count());
            }
        }
    }
}
