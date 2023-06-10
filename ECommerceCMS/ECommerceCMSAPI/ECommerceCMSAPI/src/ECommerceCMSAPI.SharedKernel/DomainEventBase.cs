using MediatR;

namespace ECommerceCMSAPI.SharedKernel;
public abstract class DomainEventBase : INotification
{
  public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
}
