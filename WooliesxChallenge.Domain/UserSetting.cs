using System;

namespace WooliesxChallenge.Domain
{
    public class UserSetting
    {
        public const string Setting = "UserSetting";
        public string Name { get; set; }
        public Guid Token { get; set; }
    }
}
