using Microsoft.AspNetCore.Identity;
using Moq;
using Track365.Models;

namespace Track365.Tests
{
    public class UserTests
    {

        [Fact]
        public async void TestIfUserIsSuccessfullyCreatedFromInput()
        {
            var userName = "test";
            var email = "test@test.com";
            var password = "test";
            var user = new User(userName, email);

            Assert.Equal(userName, user.UserName);
            Assert.Equal(email, user.Email);
        }

        public static Mock<UserManager<TUser>> MockUserManager<TUser>(List<TUser> ls) where TUser : class
        {
            var store = new Mock<IUserStore<TUser>>();
            var mgr = new Mock<UserManager<TUser>>(store.Object, null, null, null, null, null, null, null, null);
            mgr.Object.UserValidators.Add(new UserValidator<TUser>());
            mgr.Object.PasswordValidators.Add(new PasswordValidator<TUser>());

            mgr.Setup(x => x.DeleteAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success);
            mgr.Setup(x => x.CreateAsync(It.IsAny<TUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success).Callback<TUser, string>((x, y) => ls.Add(x));
            mgr.Setup(x => x.UpdateAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success);

            return mgr;
        }
    }
}