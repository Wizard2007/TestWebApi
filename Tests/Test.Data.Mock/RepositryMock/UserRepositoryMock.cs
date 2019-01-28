using Moq;
using Test.Data.Abstractions;
using Test.Data.Dummy.Generators;
using Test.Data.Models;
using System.Collections.Generic;

namespace Test.Data.Mock.RepositryMock
{
    public static class UserRepositoryMock
    {
        public static Mock<IUserRepository> GetMock() => new Mock<IUserRepository>();

        public static Mock<IUserRepository> GetMockAndSetUpAsync(IEnumerable<User> defaultUserList = null)
        {
            var repositoryMock = GetMock();
            var users = defaultUserList?? UserDummyGenerator.GenerateCollection(5);
 
            repositoryMock.Setup(repository => repository.GetAllAsync()).ReturnsAsync(() => users);

            return repositoryMock;
        }
    }
}
