using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.CQRS
{
    public interface ICommandHandler<in TCommand> 
        : IRequestHandler<TCommand, Unit>
        where TCommand : ICommand<Unit>
    {
        
    }
    public interface ICommandHandler<in TCommand, TRespone> : IRequestHandler<TCommand, TRespone>
        where TCommand : ICommand<TRespone>
        where TRespone : notnull
    {
    }
}
