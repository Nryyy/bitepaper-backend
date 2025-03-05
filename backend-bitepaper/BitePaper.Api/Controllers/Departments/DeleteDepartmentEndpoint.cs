using BitePaper.Application.Commands.Departments;
using BitePaper.Models.DTOs.Request;
using BitePaper.Models.Entities;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace BitePaper.Api.Controllers.Departments;

public class DeleteDepartmentEndpoint : EndpointWithoutRequest
{
    private readonly IMediator _mediator;

    public DeleteDepartmentEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Delete("/department-delete/{id}");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var departmentId = Route<ObjectId>("id");
        
        await _mediator.Send(new DeleteDepartmentCommand(departmentId), ct);
        await SendNoContentAsync(ct);
    }
}