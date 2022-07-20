﻿using BlazorwasmCleanArchitecture.Application.Common.Models;
using BlazorwasmCleanArchitecture.Application.TodoItems.Commands.CreateTodoItem;
using BlazorwasmCleanArchitecture.Application.TodoItems.Commands.DeleteTodoItem;
using BlazorwasmCleanArchitecture.Application.TodoItems.Commands.UpdateTodoItem;
using BlazorwasmCleanArchitecture.Application.TodoItems.Commands.UpdateTodoItemDetail;
using BlazorwasmCleanArchitecture.Application.TodoItems.Queries.GetTodoItems;
using Microsoft.AspNetCore.Mvc;

namespace BlazorwasmCleanArchitecture.Server.Controllers;

public class TodoItemsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<TodoItemBriefDto>>> GetTodoItemsWithPagination([FromQuery] GetTodoItemsQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateTodoItemCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateTodoItemCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpPut("[action]")]
    public async Task<ActionResult> UpdateItemDetails(int id, UpdateTodoItemDetailCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteTodoItemCommand(id));

        return NoContent();
    }
}