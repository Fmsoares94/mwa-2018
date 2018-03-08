using System;
using System.Collections.Generic;
using System.Text;
using FluentValidator;

namespace ModernStore.Domain.ValueObjects
{
    public class Name : Notifiable
    {
        protected Name() { }

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            new ValidationContract<Name>(this)
                .IsRequired(x => x.FirstName, "Nome é Obrigatório")
                .HasMaxLenght(x => x.FirstName, 60, "Nome tem que ser menor que 60 caracteres")
                .HasMinLenght(x => x.FirstName, 3, "Minimo de 3 caracteres")

                .IsRequired(x => x.LastName, "Sobrenome é Obrigatório")
                .HasMaxLenght(x => x.LastName, 60, "Sobrenome tem que ser menor que 60 caracteres")
                .HasMinLenght(x => x.LastName, 3, "Minimo de 3 caracteres");

        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
