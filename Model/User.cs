using Middleware;
using System;

namespace Model
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public int RoleId { get; set; }

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
