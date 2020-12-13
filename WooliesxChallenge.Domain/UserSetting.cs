using System;
using System.Collections.Generic;
using System.Text;

namespace WooliesxChallenge.Domain
{
    public class UserSetting
    {
        public const string Setting = "UserSetting";
        public string Name { get; set; }
        public Guid Token { get; set; }
    }
}
