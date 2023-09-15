using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Application;
using Server.Application.Task.Commands.CreateTask;
using System.ComponentModel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator =>
                _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected async Task<P> CreateData<T, P>(T command)
        {
            var result = await Mediator.Send(command, CancellationToken.None);
            return (P)result;
        }

        protected async Task<P> GetData<T, P>(object? data)
        {
            var query = Activator.CreateInstance(typeof(T), new object[] { data });
            var result = await Mediator.Send(query, CancellationToken.None);
            return (P)result;
        }

    }
}
