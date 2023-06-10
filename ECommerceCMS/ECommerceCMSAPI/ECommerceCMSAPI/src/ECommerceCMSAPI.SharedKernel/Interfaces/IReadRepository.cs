using Ardalis.Specification;

namespace ECommerceCMSAPI.SharedKernel.Interfaces;
public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}
