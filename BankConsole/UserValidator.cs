using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsole
{
    public class UserValidator: AbstractValidator<User>
    {

        public UserValidator()
        {
            RuleFor(user => user.GetID()).NotEmpty();
        }
    }
}
