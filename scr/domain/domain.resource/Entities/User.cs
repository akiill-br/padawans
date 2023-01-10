using ApiResource.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiResource.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string Email { get; private set; }
        public string Password { get;private set; }
        public string Role { get; set; }

        public User(string email, string password)
        {
            Validation(email, password);
            Role = "user";
        }
        public User(int id, string email, string password)
        {
            DomainValidationException.When(id <= 0, "Id Usuario deve ser válido");
            Validation(email, password);
            Id = id;
        }

        private void Validation(string email, string password)
        {
            DomainValidationException.When(string.IsNullOrEmpty(email), "Email deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(password), "Password deve ser informado!");
            //DomainValidationException.When(role != "admin" || role != "user", "Role deve ser valido!");

            Email = email;
            Password = password;
            
        }
    }
}
