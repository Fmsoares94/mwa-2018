using ModernStore.Shared.Commands;

namespace ModernStore.Domain.Commands.Results
{
    class RegisterOrderCommandResult : ICommandResult
    {
        public RegisterOrderCommandResult()
        {
            
        }

        public RegisterOrderCommandResult( string number)
        {
            Number = number;
        }

        public string Number { get; set; }
    }
}
