using Microsoft.EntityFrameworkCore;
using Moq;
using Test.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Data.Mock.EntityFrameWorkMock
{
    public static class UnitOfWorkMock
    {
        public static Mock<IUnitOfWork> GetMock() => new Mock<IUnitOfWork>();

        public static Mock<IUnitOfWork> GetMockAndSetUpContext(Mock<DbContext> mockDbContext)
        {
            var mockUnitOfWork = GetMock();          
            
            mockUnitOfWork.Setup(u => u.Context).Returns(mockDbContext.Object);

            return mockUnitOfWork;
        }
    }
}
