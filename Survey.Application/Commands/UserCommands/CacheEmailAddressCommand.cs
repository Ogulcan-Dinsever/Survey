using MediatR;
using Survey.Application.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Commands.UserCommands
{
    public class CacheEmailAddressCommand : IRequest<Response<bool>>
    {
        public string Email { get; set; }
    }
}
