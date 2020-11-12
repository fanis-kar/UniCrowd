using Middleware;
using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    // Authentication.API

    public class User
    {
        public int Id { get; set; }

        [Display(Name = "Όνομα χρήστη")]
        public string Username { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Κωδικός πρόσβασης")]
        public string Password { get; set; }

        public string Salt { get; set; }

        [Display(Name = "Ρόλος")]
        public int RoleId { get; set; }

        [Display(Name = "Ρόλος")]
        public Role Role { get; set; }

        public void SetPassword(string password, IEncryptor encryptor)
        {
            Salt = encryptor.GetSalt(password);
            Password = encryptor.GetHash(password, Salt);
        }

        public bool ValidatePassword(string password, IEncryptor encryptor)
        {
            var isValid = Password.Equals(encryptor.GetHash(password, Salt));
            return isValid;
        }
    }
}
