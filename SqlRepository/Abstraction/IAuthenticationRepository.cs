using System;
using System.Collections.Generic;
using System.Text;
using DAL.Security;
using System.Threading.Tasks;

namespace SqlRepository.Abstraction
{
    public interface IAuthenticationRepository
    {

        bool CreateUser(User user, string password);
        User AuthenticateUser(string username, string password);
        Task<bool> SignOut();

        string GenerateJSONWebToken(User userInfo);

    }
}
