using Ardalis.Specification;
using ECommerceCMSAPI.Core.ContributorAggregate;

namespace ECommerceCMSAPI.Core.ProjectAggregate.Specifications;
public class ContributorByIdSpec : Specification<Contributor>, ISingleResultSpecification
{
  public ContributorByIdSpec(int contributorId)
  {
    Query
        .Where(contributor => contributor.Id == contributorId);
  }
}
