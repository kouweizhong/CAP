﻿using System;
using DotNetCore.CAP.Job;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetCore.CAP
{
    /// <summary>
    /// Used to verify cap service was called on a ServiceCollection
    /// </summary>
    public class CapMarkerService
    {
    }

    /// <summary>
    /// Allows fine grained configuration of CAP services.
    /// </summary>
    public class CapBuilder
    {
        public CapBuilder(IServiceCollection services)
        {
            Services = services;
        }

        /// <summary>
        /// Gets the <see cref="IServiceCollection"/> where MVC services are configured.
        /// </summary>
        public IServiceCollection Services { get; private set; }

        /// <summary>
        /// Adds a scoped service of the type specified in serviceType with an implementation
        /// </summary>
        private CapBuilder AddScoped(Type serviceType, Type concreteType)
        {
            Services.AddScoped(serviceType, concreteType);
            return this;
        }

        /// <summary>
        /// Adds a singleton service of the type specified in serviceType with an implementation
        /// </summary>
        private CapBuilder AddSingleton<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService
        {
            Services.AddSingleton<TService, TImplementation>();
            return this;
        }

        /// <summary>
        /// Add an <see cref="ICapMessageStore"/> .
        /// </summary>
        /// <typeparam name="T">The type for the <see cref="ICapMessageStore"/> to add. </typeparam>
        /// <returns>The current <see cref="CapBuilder"/> instance.</returns>
        public virtual CapBuilder AddMessageStore<T>()
            where T : class, ICapMessageStore
        {
            return AddScoped(typeof(ICapMessageStore), typeof(T));
        }

        /// <summary>
        /// Add an <see cref="IJob"/> for process <see cref="CapJob"/>.
        /// </summary>
        /// <typeparam name="T">The type of the job.</typeparam>
        public virtual CapBuilder AddJobs<T>()
            where T : class, IJob
        {
            return AddSingleton<IJob, T>();
        }

        /// <summary>
        /// Add an <see cref="ICapPublisher"/>.
        /// </summary>
        /// <typeparam name="T">The type of the service.</typeparam>
        public virtual CapBuilder AddProducerService<T>()
            where T : class, ICapPublisher
        {
            return AddScoped(typeof(ICapPublisher), typeof(T));
        }
    }
}