using System;
using ModernStore.Shared.Commands;

namespace ModernStore.Domain.Commands.Results
{
    public class GetProductCommandResult : ICommandResult
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
    }
}
