using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.CQRS
{
    // representação de um comando, que é uma solicitação para realizar uma ação ou operação específica.
    public interface ICommand : ICommand<Unit>
    {
    }

    // representação de um comando que retorna uma resposta do tipo TResponse. O tipo TResponse é genérico, o que significa que pode ser qualquer tipo de dado que o comando precise retornar após a execução.
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
