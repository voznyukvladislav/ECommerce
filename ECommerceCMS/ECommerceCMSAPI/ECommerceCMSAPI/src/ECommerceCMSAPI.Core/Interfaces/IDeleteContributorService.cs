using Ardalis.Result;

namespace ECommerceCMSAPI.Core.Interfaces;
public interface IDeleteContributorService
{
  public Task<Result> DeleteContributor(int contributorId);
}
