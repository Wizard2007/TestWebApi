using Test.Data.Models;
using System;
using System.Collections.Generic;

namespace Test.Data.Dummy.Generators
{
    public static class UserDummyGenerator
    {
        public static User Generate(int i = 0) => new User() { UserId = i, Name = $"Name{i}" };
        public static IEnumerable<User>GenerateCollection (int count)
        {
            var users = new List<User>(count);

            for (int i = 0; i< count; i++ )
            {
                users.Add(Generate(i));
            }

            return users;
        }
    }
}
