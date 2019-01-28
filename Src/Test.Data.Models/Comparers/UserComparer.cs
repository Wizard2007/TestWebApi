using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Data.Models.Comparers
{
    public class UserComparer : IEqualityComparer<User>
    {
        public bool Equals(User x, User y)
        {
            if (Object.ReferenceEquals(x, y)) return true;

            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            return (x.UserId == y.UserId && x.Name == y.Name);
        }

        public int GetHashCode(User obj)
        {
            if (Object.ReferenceEquals(obj, null)) return 0;

            int hashObjName = obj.Name == null ? 0 : obj.Name.GetHashCode();

            int hashObjUserID = obj.UserId.GetHashCode();

            return hashObjName ^ hashObjUserID;
        }
    }
}
