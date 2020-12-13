using System.Collections.Generic;
using System.Text;
using WooliesxChallenge.Domain;
using WooliesxChallenge.Domain.Models;

namespace WooliesxChallenge.Application
{
    
    public interface IUserService
    {
        UserModel GetUser();
    }
}
