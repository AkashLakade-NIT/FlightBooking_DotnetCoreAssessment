using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Security
{
    public class User : IdentityUser<int>
    {
        [NotMapped]
        public IEnumerable<string> Roles { get; set; }
    }
}
