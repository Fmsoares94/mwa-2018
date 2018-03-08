using System;
using System.Collections.Generic;
using System.Text;
using FluentValidator;

namespace ModernStore.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        protected Email() { }

        public Email(string address)
        {
            Address = address;

            new ValidationContract<Email>(this)
                .IsEmail(x => x.Address, "Email é invalido");
        }

        public string Address { get; private set; }

    }
}
