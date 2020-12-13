using System;
using FluentAssertions;
using Microsoft.Extensions.Options;
using WooliesxChallenge.Application;
using WooliesxChallenge.Domain;
using Xunit;

namespace WooliexChallenge.UnitTests
{
    public class UserServiceTests
    {
        [Fact]
        public void GivenOptionWithValueCallGetUserShouldReturnSameValue()
        {
            var token = Guid.NewGuid();
            var name = "SYED BASHAR";
            var option = Options.Create<UserSetting>(new UserSetting {Token = token, Name = name});

            var userService = new UserService(option);

            var user = userService.GetUser();

            user.Token.Should().Be(token);
            user.Name.Should().Be(name);
        }

        [Fact]
        public void GivenEmptyNameValueCallGetUserShouldReturnException()
        {
            var token = Guid.NewGuid();
            var name = "";
            var option = Options.Create<UserSetting>(new UserSetting { Token = token, Name = name });

            var userService = new UserService(option);

            Action act = () => userService.GetUser();
            act.Should().Throw<Exception>().WithMessage("User setting is not correct.");
        }
    }
}
