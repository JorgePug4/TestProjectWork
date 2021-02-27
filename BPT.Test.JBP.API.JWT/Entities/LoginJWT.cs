using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BPT.Test.JBP.API.JWT.Entities
{
    public class LoginJWT
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
    }


}
