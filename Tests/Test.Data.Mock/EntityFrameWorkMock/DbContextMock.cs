using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Data.Mock.EntityFrameWorkMock
{
    public static class DbContextMock<TDbContext> where TDbContext : DbContext
    {
        public static Mock<TDbContext> GetMock() => new Mock<TDbContext>();

        public static Mock<TDbContext> GetMockAndSetUpDbSet<T>(Mock<DbSet<T>> mockDbSet = null) where T: class
        {
            var mockDbContext = GetMock();
            var mockDbSetT = mockDbSet ?? DbSetMock<T>.GetMock();

            mockDbContext.Setup(db => db.Set<T>()).Returns(mockDbSetT.Object);

            return mockDbContext;
        }
    }
}
