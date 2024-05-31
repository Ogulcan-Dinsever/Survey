using MediatR;
using Survey.Application.Commands.UserCommands;
using Survey.Application.Repositories.Interfaces;
using Survey.Application.Responses;
using Survey.Application.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Handlers.UserHandlers.CommandHandlers
{
    public class CacheEmailAddressHandler : IRequestHandler<CacheEmailAddressCommand, Response<bool>>
    {
        private readonly ICacheService _cacheService;

        public CacheEmailAddressHandler(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }
        public async Task<Response<bool>> Handle(CacheEmailAddressCommand request, CancellationToken cancellationToken)
        {
            if (!GlobalFunctions.EmailControll(request.Email))
                return Response<bool>.Fail("this is not an e-mail", 201);

            await _cacheService.SetAsync("email", request.Email, TimeSpan.FromDays(10));

            return Response<bool>.Success(true, 201);
        }
    }
}
