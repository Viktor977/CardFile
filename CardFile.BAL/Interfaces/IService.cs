using System;
using System.Collections.Generic;
using System.Text;

namespace CardFile.BAL.Interfaces
{
   public interface IService
    {
       public IUserService UserService { get; }
    }
}
