using Ardalis.Result;
using ECommerceCMSAPI.Core.ContributorAggregate;
using ECommerceCMSAPI.Core.ContributorAggregate.Events;
using ECommerceCMSAPI.Core.Interfaces;
using ECommerceCMSAPI.SharedKernel.Interfaces;
using MediatR;

namespace ECommerceCMSAPI.Core.Services;
public class DeleteContributorService : IDeleteContributorService
{
  private readonly IRepository<Contributor> _repository;
  private readonly IMediator _mediator;

  public DeleteContributorService(IRepository<Contributor> repository, IMediator mediator)
  {
    _repository = repository;
    _mediator = mediator;
  }

  public async Task<Result> DeleteContributor(int contributorId)
  {
    var aggregateToDelete = await _repository.GetByIdAsync(contributorId);
    if (aggregateToDelete == null) return Result.NotFound();

    await _repository.DeleteAsync(aggregateToDelete);
    var domainEvent = new ContributorDeletedEvent(contributorId);
    await _mediator.Publish(domainEvent);
    return Result.Success();
  }
}
