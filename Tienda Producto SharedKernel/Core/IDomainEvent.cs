using System;
using MediatR;

namespace Tienda_Inventario_SharedKernel.Core
{
    public interface IDomainEvent : INotification
    {
        DateTime OccurredOn { get; }
    }
}