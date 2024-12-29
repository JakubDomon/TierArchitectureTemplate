﻿using BusinessLayer.Models.Communication.Handlers.Specific;
using Domain.DTO.Requests;
using Domain.DTO.Responses;
using Domain.Logic.Common.Handlers;

namespace Domain.Logic.Common.Handlers.Providers
{
    internal class HandlerProvider : IHandlerProvider
    {
        private readonly IServiceProvider _serviceProvider;

        internal HandlerProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IHandler<Input, Output> GetHandler<Input, Output>()
            where Input : RequestBase
            where Output : ResponseBase
        {
            var handler = _serviceProvider.GetService(typeof(IHandler<Input, Output>));

            if (handler == null)
                throw new InvalidOperationException($"No handler found for types {typeof(Input).Name}, {typeof(Output).Name}");

            return (IHandler<Input, Output>)handler;
        }
    }
}