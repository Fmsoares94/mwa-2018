using System;
using System.Collections.Generic;
using System.Text;
using FluentValidator;
using ModernStore.Shared.Entities;

namespace ModernStore.Domain.Entities
{
    public class User : Entity
    {
        protected User()
        {

        }

        public User( string username, string passWord, string confirmPassWord)
        {
           
            Username = username;
            PassWord = passWord;
            ConfirmPassword = confirmPassWord;
            Active = true;

            new ValidationContract<User>(this)
                .AreEquals(x => x.PassWord, confirmPassWord, "As senhas não coincidem");
        }

        public string Username { get; private set; }

        public string PassWord { get; private set; }

        public bool Active { get; private set; }

        public string ConfirmPassword { get; private set; }

        public void Activate() => Active = true;

        public void Deactivate() => Active = false;
        


    }
}
