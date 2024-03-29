﻿using GymBro.Application.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Application.Common.Behaviours
{
    public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly Stopwatch _timer;
        private readonly ILogger<TRequest> _logger;
        private readonly ICurrentUserService _currentUserService;

        public PerformanceBehaviour( ILogger<TRequest> logger, ICurrentUserService currentUserService)
        {
             _timer = new Stopwatch(); ;
            _logger = logger;
            _currentUserService = currentUserService;
        }

        public async  Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _timer.Start();
            var response = await next();
            _timer.Stop();

            var elapsedMilliseconds = _timer.ElapsedMilliseconds;

            if (elapsedMilliseconds > 500)
            {
                var requestName = typeof(TRequest).Name;
                var userName = _currentUserService.UserName ;
                if (!string.IsNullOrEmpty(userName))
                {
                    _logger.LogWarning("GymBro Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds)  {@UserName} {@Request}",
                    requestName, elapsedMilliseconds,  userName, request);
                }
            }
            return response;
        }
    }
}
