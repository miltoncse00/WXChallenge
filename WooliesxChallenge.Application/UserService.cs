using System;
using Microsoft.Extensions.Options;
using WooliesxChallenge.Domain;
using WooliesxChallenge.Domain.Models;

namespace WooliesxChallenge.Application
{
    public class UserService : IUserService
    {
        private readonly UserSetting _user;

        public UserService(IOptions<UserSetting> userSettingOptions)
        {
            _user = userSettingOptions.Value;
        }
        public UserModel GetUser()
        {
            if (_user == null || string.IsNullOrEmpty(_user.Name))
                throw new Exception("User setting is not correct.");
            return new UserModel{Name = _user.Name, Token = _user.Token};
        }
    }
}