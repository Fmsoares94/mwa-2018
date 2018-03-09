using FluentValidator;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Domain.Commands.Results;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Domain.ValueObjects;
using ModernStore.Shared.Commands;

namespace ModernStore.Domain.Commands.Handler
{
    public class CustomerCommandHandler : Notifiable,
        ICommandHandler<RegisterCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public ICommandResult Handle(RegisterCustomerCommand command)
        {
            //Verificar se o CPF é valido
            if (_customerRepository.DocumentExists(command.Document))
            {
                AddNotification("Document", "Este CPF ja existe");
                return null;
            }

            //Gerar o novo cliente
            var name = new Name(command.FirstName, command.LastName);
            var email = new Email(command.Email);
            var document = new Document(command.Document);
            var user = new User(command.UserName, command.Password, command.ConfirmPassword);
            var customer = new Customer(name, email, document, user);

            //Adicionando as notificações
            AddNotifications(name.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(user.Notifications);
            AddNotifications(customer.Notifications);


            if (!IsValid())
                return null;
                //Inserir no banco
                _customerRepository.Save(customer);

            // Enviar E-mail de boas vindas


            // Retornar algo

            return new RegisterCustomerCommandResult(customer.Id, customer.Name.ToString());


        }
    }
}
