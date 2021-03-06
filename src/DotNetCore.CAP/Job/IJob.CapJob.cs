﻿using System;
using System.Threading.Tasks;
using DotNetCore.CAP.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using DotNetCore.CAP.Abstractions;
using DotNetCore.CAP.Infrastructure;

namespace DotNetCore.CAP.Job
{
    public class CapJob : IJob
    {
        private readonly MethodMatcherCache _selector;
        private readonly IConsumerInvokerFactory _consumerInvokerFactory;
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<CapJob> _logger;
        private readonly ICapMessageStore _messageStore;

        public CapJob(
            ILogger<CapJob> logger,
            IServiceProvider serviceProvider,
            IConsumerInvokerFactory consumerInvokerFactory,
            ICapMessageStore messageStore,
            MethodMatcherCache selector)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _consumerInvokerFactory = consumerInvokerFactory;
            _messageStore = messageStore;
            _selector = selector;
        }

        public async Task ExecuteAsync()
        {
            //var groupedCandidates = _selector.GetCandidatesMethodsOfGroupNameGrouped(_serviceProvider);
            //using (var scope = _serviceProvider.CreateScope())
            //{
            //    var provider = scope.ServiceProvider;

            //    var messageStore = provider.GetService<ICapMessageStore>();
            //    var nextReceivedMessage = await messageStore.GetNextReceivedMessageToBeExcuted();
            //    if (nextReceivedMessage != null && groupedCandidates.ContainsKey(nextReceivedMessage.Group))
            //    {
            //        try
            //        {
            //            await messageStore.ChangeReceivedMessageStateAsync(nextReceivedMessage, StatusName.Processing);
            //            // If there are multiple consumers in the same group, we will take the first
            //            var executeDescriptor = groupedCandidates[nextReceivedMessage.Group][0];
            //            var consumerContext = new ConsumerContext(executeDescriptor, nextReceivedMessage.ToMessageContext());
            //            var invoker = _consumerInvokerFactory.CreateInvoker(consumerContext);
            //            await invoker.InvokeAsync();
            //            await messageStore.ChangeReceivedMessageStateAsync(nextReceivedMessage, StatusName.Succeeded);

            //        }
            //        catch (Exception ex)
            //        {
            //            _logger.ReceivedMessageRetryExecutingFailed(nextReceivedMessage.KeyName, ex);
            //        }
            //    }
            //}
        }
    }
}