//https://rubikscode.net/2018/04/16/implementing-and-testing-repository-pattern-using-entity-framework/
//https://docs.microsoft.com/en-us/ef/ef6/fundamentals/testing/mocking
//http://qaru.site/questions/1257303/idbasyncqueryprovider-in-entityframeworkcore
//https://www.jankowskimichal.pl/en/2017/03/entityframework-asynchronous-queries-unit-tests/
using Microsoft.EntityFrameworkCore;
using Moq;
using Test.Data.Dummy.Generators;
using Test.Data.Mock.EntityFrameWorkMock;
using Test.Data.Models;
using Test.Data.Models.Comparers;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Test.Data.Entities.Tests
{
    public class UserRepositoryEFTest
    {
        [Fact]
        public void UserRepositoryEFTest_Create()
        {
            var mockDbContext = DbContextMock<DbContext>.GetMock();
            var mockUnitOfWork = UnitOfWorkMock.GetMockAndSetUpContext(mockDbContext);
            var userRepositoryEF = new UserRepositoryEF(mockUnitOfWork.Object);

            mockDbContext.Verify(x => x.Set<User>());
        }

        [Fact]
        public async Task UserRepositoryEFTest_GetAll()
        {            
            var users = UserDummyGenerator.GenerateCollection(5);
            var mockDbSet = DbSetMock<User>.GetMockAndSetUpQueryble(users);
            var mockDbContext = DbContextMock<DbContext>.GetMockAndSetUpDbSet(mockDbSet);
            var mockUnitOfWork = UnitOfWorkMock.GetMockAndSetUpContext(mockDbContext);
            var userRepositoryEF = new UserRepositoryEF(mockUnitOfWork.Object);
            var resultUsers = await userRepositoryEF.GetAllAsync();

            Assert.True(Enumerable.SequenceEqual(users.OrderBy(t => t.UserId), resultUsers.OrderBy(t => t.UserId), new UserComparer()));
        }

        [Fact]
        public async Task UserRepositoryEFTest_Add()
        {
            var user = UserDummyGenerator.Generate();
            var mockDbSet = new Mock<DbSet<User>>();
            var mockDbContext = DbContextMock<DbContext>.GetMockAndSetUpDbSet(mockDbSet);
            var mockUnitOfWork = UnitOfWorkMock.GetMockAndSetUpContext(mockDbContext);

            var repositoryUser = new UserRepositoryEF(mockUnitOfWork.Object);
            await repositoryUser.AddAsync(user);

            mockDbSet.Verify(m => m.AddAsync(It.Is<User>(y => y == user), It.IsAny<System.Threading.CancellationToken>()), Times.Once());
        }
    }
}
