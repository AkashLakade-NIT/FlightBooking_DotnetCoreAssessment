using DAL.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SqlRepository.Abstraction;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SqlRepository.Implementation
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        protected UserManager<User> userManager;
        protected RoleManager<Role> roleManager;
        protected SignInManager<User> signInManager;
        private IConfiguration config;
        public AuthenticationRepository(UserManager<User> _userManager
            , RoleManager<Role> _roleManager
            , SignInManager<User> _signInManager
            , IConfiguration _config)
        {
            userManager = _userManager;
            roleManager = _roleManager;
            signInManager = _signInManager;
            config = _config;

        }

        public bool CreateUser(User user, string password)
        {
            var result = userManager.CreateAsync(user, password).Result;
            if (result.Succeeded)
            {
                //Fetch details of "User" role
                var role = roleManager.FindByNameAsync("User").Result;
                if (role != null)
                {
                    //Add new user to "User" role
                    var assign = userManager.AddToRoleAsync(user, role.Name).Result;
                    if (assign.Succeeded)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public User AuthenticateUser(string username, string password)
        {
            var result = signInManager.PasswordSignInAsync(username, password, false, false).Result;
            if (result.Succeeded)
            {
                //Fetch user details
                var user = userManager.FindByNameAsync(username).Result;

                //Fetch all roles assigned to that logged in user
                var roles = userManager.GetRolesAsync(user).Result;

                user.Roles = roles.ToArray();

                return user;
            }
            return null;
        }

        public async Task<bool> SignOut()
        {
            await signInManager.SignOutAsync();
            return true;
        }

        public string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                             new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
                             new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                             new Claim(JwtRegisteredClaimNames.Sid, userInfo.PhoneNumber),
                             new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                             new Claim(JwtRegisteredClaimNames.Typ, String.Join(",", userInfo.Roles))
                            };

            var token = new JwtSecurityToken(config["Jwt:Issuer"],
                                            config["Jwt:Audience"],
                                            claims,
                                            expires: DateTime.Now.AddMinutes(1),
                                            signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
