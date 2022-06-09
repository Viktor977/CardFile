using CardFile.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CardFile.TESTS
{
    internal class UserEqualityComparer : IEqualityComparer<User>
    {
        public bool Equals([AllowNull] User x, [AllowNull] User y)
        {
            if (x == null && y == null)
            {
                return true;
            }
            if(x==null || y == null)
            {
                return false;
            }

            return x.Id == y.Id
                && x.FirstName == y.FirstName
                && x.LastName == y.LastName
                && x.Role == y.Role;
        }
       
        public int GetHashCode([DisallowNull] User obj)
        {
            return obj.GetHashCode();
        }
    }

    internal class UserProfileEqualityCompare : IEqualityComparer<UserProfile>
    {
        public bool Equals([AllowNull] UserProfile x, [AllowNull] UserProfile y)
        {
            if(x==null && y == null)
            {
                return true;
            }
            if(x==null || y == null)
            {
                return false;
            }
            return x.Id == y.Id
                && x.Login == y.Login
                && x.Password == y.Password
                && x.UserId == y.UserId;
        }

        public int GetHashCode([DisallowNull] UserProfile obj)
        {
            return obj.GetHashCode();
        }
    }
}
