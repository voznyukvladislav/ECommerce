﻿using Ardalis.HttpClientTestExtensions;
using ECommerceCMSAPI.Web;
using ECommerceCMSAPI.Web.ApiModels;
using Xunit;

namespace ECommerceCMSAPI.FunctionalTests.ControllerApis;
[Collection("Sequential")]
public class ProjectCreate : IClassFixture<CustomWebApplicationFactory<Program>>
{
  private readonly HttpClient _client;

  public ProjectCreate(CustomWebApplicationFactory<Program> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact]
  public async Task ReturnsOneProject()
  {
    var result = await _client.GetAndDeserializeAsync<IEnumerable<ProjectDTO>>("/api/projects");

    Assert.Single(result);
    Assert.Contains(result, i => i.Name == SeedData.TestProject1.Name);
  }
}
