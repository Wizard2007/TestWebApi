using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Test.Data.Mock.EntityFrameWorkMock
{
    public static class DbSetMock<T> where T: class
    {
        public static Mock<DbSet<T>> GetMock() => new Mock<DbSet<T>>();

        public static Mock<DbSet<T>> GetMockAndSetUpQueryble(IEnumerable<T> list)
        {
            var mockDbSet = GetMock();
            var listQueryble = list.AsQueryable();
            var dbSetQueryble = mockDbSet.As<IQueryable<T>>();

            
            mockDbSet.As<IAsyncEnumerable<T>>()
                .Setup(d => d.GetEnumerator())
                .Returns(new AsyncEnumerator<T>(listQueryble.GetEnumerator()));

            dbSetQueryble.Setup(x => x.Provider).Returns(listQueryble.Provider);
            dbSetQueryble.Setup(x => x.Expression).Returns(listQueryble.Expression);
            dbSetQueryble.Setup(x => x.ElementType).Returns(listQueryble.ElementType);
            dbSetQueryble.Setup(x => x.GetEnumerator()).Returns(listQueryble.GetEnumerator());

            return mockDbSet;
        }
        
        public static Mock<DbSet<T>> GetMockAndSetUpAdd(T model)
        {
            var mockDbSet = GetMock();

            //mockDbSet.Setup(x => x.Add(It.IsAny<T>())).Returns(model);

            return mockDbSet;
        }

        internal class AsyncEnumerable<T> : EnumerableQuery<T>, IAsyncEnumerable<T>, IQueryable<T>
        {
            public AsyncEnumerable(Expression expression)
                : base(expression) { }

            public IAsyncEnumerator<T> GetEnumerator() =>
                new AsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
        }

        internal class AsyncEnumerator<T> : IAsyncEnumerator<T>
        {
            private readonly IEnumerator<T> enumerator;

            public AsyncEnumerator(IEnumerator<T> enumerator) =>
                this.enumerator = enumerator ?? throw new ArgumentNullException();

            public T Current => enumerator.Current;

            public void Dispose() { }

            public Task<bool> MoveNext(CancellationToken cancellationToken) =>
                Task.FromResult(enumerator.MoveNext());
        }

    }
}
