using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Test.Data.Dummy.Generators;
using Test.Data.Mock.EntityFrameWorkMock;
using Test.Data.Mock.RepositryMock;
using Test.Data.Models;
using Test.Data.Models.Comparers;
using Test.Web.Api.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
//https://www.codeproject.com/Articles/1239785/Implementing-and-Testing-Repository-Pattern-using
//https://www.codeproject.com/Articles/488264/%2FArticles%2F488264%2FUnit-testing-made-easy-Part-1-Repository-Testing
namespace Test.Web.Api.Tests.Controllers
{
    public class UsersControllerTests
    {

        [Fact]
        public async Task UsersControllerTests_GetAll()
        {
            var users = UserDummyGenerator.GenerateCollection(5) as List<User>;
            var userRepository = UserRepositoryMock.GetMockAndSetUpAsync(users);
            var unitOfWork = UnitOfWorkMock.GetMock();
            var userController = new UsersController(unitOfWork.Object, userRepository.Object);
            var result = await userController.GetAll();            

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);

            var resultUsers = (result as OkObjectResult).Value as List<User>;

            Assert.True(Enumerable.SequenceEqual(users.OrderBy(t => t.UserId), resultUsers.OrderBy(t => t.UserId), new UserComparer()));
        }

        [Fact]
        public async Task UsersControllerTests_CreateUser()
        {
            var user = UserDummyGenerator.Generate();
            var userRepository = UserRepositoryMock.GetMock();
            var unitOfWork = UnitOfWorkMock.GetMock();
            var userController = new UsersController(unitOfWork.Object, userRepository.Object);

            var result = await userController.CreateUser(user);

            Assert.NotNull(result);
            Assert.IsType<OkResult>(result);

            userRepository.Verify(x => x.AddAsync(It.Is<User>(y => y == user)));
            unitOfWork.Verify(x => x.CommitAsync());
        }
    }
}
