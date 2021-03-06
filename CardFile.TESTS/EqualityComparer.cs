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
            if(x == null || y == null)
            {
                return false;
            }

            return x.Id == y.Id
                && x.FirstName == y.FirstName
                && x.LastName == y.LastName
                && x.Role == y.Role
                && x.Email == y.Email
                && x.Password == y.Password;
               
        }
       
        public int GetHashCode([DisallowNull] User obj)
        {
            return obj.GetHashCode();
        }
    }

    internal class HistoryEqualityCompare : IEqualityComparer<History>
    {
        public bool Equals([AllowNull] History x, [AllowNull] History y)
        {
            if (x is null && y is null)
            {
                return true;
            }
            if (x is null || y is null)
            {
                return false;
            }

            return x.Id == y.Id
                           && x.LastAction == y.LastAction
                           && x.ReaderId == y.ReaderId
                           && x.TextId == y.TextId;
        }

        public int GetHashCode([DisallowNull] History obj)
        {
            return obj.GetHashCode();
        }
    }
    internal class TextMaterialEqualityComparer : IEqualityComparer<TextMaterial>
    {
        public bool Equals([AllowNull] TextMaterial x, [AllowNull] TextMaterial y)
        {
            if (x is null && y is null)
            {
                return true;
            }
            if (x is null || y is null)
            {
                return false;
            }

            return x.Id == y.Id
                           && x.Title == y.Title
                           && x.DatePublish == y.DatePublish
                           && x.Author == y.Author
                           && x.Article == y.Article;
        }

        public int GetHashCode([DisallowNull] TextMaterial obj)
        {
            return obj.GetHashCode();
        }
    }
    internal class ReactionEqualityComparer : IEqualityComparer<Reaction>
    {
        public bool Equals([AllowNull] Reaction x, [AllowNull] Reaction y)
        {
            if (x is null && y is null)
            {
                return true;
            }
            if (x is null || y is null)
            {
                return false;
            }

            return x.Id == y.Id
                && x.TextId == y.TextId
                && x.Assessment == y.Assessment
                && x.Comment == y.Comment
                && x.UserId == y.UserId;
        }

        public int GetHashCode([DisallowNull] Reaction obj)
        {
            return obj.GetHashCode();
        }
    }
}
