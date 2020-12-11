using System.Collections.Generic;
using System.Text;
using WooliesxChallenge.Domain;

namespace WooliesxChallenge.Application
{
    
    public interface IUserService
    {
        UserModel GetUser();
    }
}
