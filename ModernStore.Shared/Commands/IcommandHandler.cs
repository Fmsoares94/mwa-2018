using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStore.Shared.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
