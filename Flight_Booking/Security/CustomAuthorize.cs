using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using SqlRepository.Abstraction;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Booking.Security
{
    public class CustomAuthorize : Attribute, IAuthorizationFilter
    {

        public string Role { get; set; }
        public CustomAuthorize()
        {
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //if(context.HttpContext.User.Identity.IsAuthenticated)
            //{
            //    context.Result = new StatusCodeResult(StatusCodes.Status200OK);
            //}
            //context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);

            string token = "";
            string authorization = context.HttpContext.Request.Headers["Authorization"];
            // If no authorization header found, nothing to process further
            if (string.IsNullOrEmpty(authorization))
            {
                context.Result = new UnauthorizedResult();
            }
            else if (authorization.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                token = authorization.Substring("Bearer ".Length).Trim();
            }

            if (!string.IsNullOrEmpty(token))
            {
                bool isAuthenticated = ValidateToken(token);
                if (!isAuthenticated)
                {
                    context.Result = new UnauthorizedResult();
                }
            }
            else
            {
                context.Result = new UnauthorizedResult();
            }
        }

        //Validate the token passed in the url header
        private bool ValidateToken(string token)
        {
            SecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes("Authkey"));
            TokenValidationParameters validationParameters =
                    new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = "www.abc.com",
                        ValidAudiences = new[] { "www.abc.com" },
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = key
                    };

            SecurityToken validatedToken;
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            var user = handler.ValidateToken(token, validationParameters, out validatedToken);

            //Check for role
            var userClaims = user.Claims.Where(d => d.Type == "typ").FirstOrDefault();
            string[] roles = userClaims.Value.Split(",");
            if (roles.Contains(Role))
            {
                return user.Identity.IsAuthenticated;
            }

            return !user.Identity.IsAuthenticated;

        }
    }
}
