using ApplicationCore.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface IUserService
    {
        UserOut Authenticate(UserIn user);
        IEnumerable<UserOut> GetAll();
    }
}
