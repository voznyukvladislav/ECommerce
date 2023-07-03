﻿using Ardalis.Result;
using ECommerceCMSAPI.Core.ProjectAggregate;

namespace ECommerceCMSAPI.Core.Interfaces;
public interface IToDoItemSearchService
{
  Task<Result<ToDoItem>> GetNextIncompleteItemAsync(int projectId);
  Task<Result<List<ToDoItem>>> GetAllIncompleteItemsAsync(int projectId, string searchString);
}