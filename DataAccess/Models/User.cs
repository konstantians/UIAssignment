﻿namespace DataAccess.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string RecoveryQuestion { get; set; }
        public string RecoveryAnswer { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
