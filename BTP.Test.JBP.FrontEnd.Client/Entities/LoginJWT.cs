using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BTP.Test.JBP.FrontEnd.Client.Entities
{
    public class LoginJWT
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
