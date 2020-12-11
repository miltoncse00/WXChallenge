using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using WooliesxChallenge.Domain;

namespace WooliesxChallenge.Application
{
    public class UserService : IUserService
    {
        private readonly UserModel _user;

        public UserService(UserModel user)
        {
            _user = user;
        }
        public UserModel GetUser()
        {
            if (_user == null || string.IsNullOrEmpty(_user.Name))
                throw new Exception("User setting is not correct.");
            return _user;
        }
    }
}