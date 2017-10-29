using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Wcf;

namespace RobotArm.HostingCommon.Initializing
{
    public class CustomServiceHostInitializer : IServiceHostInitializer
    {
        private readonly ILifetimeScope _lifetimeScope;
        private readonly List<ServiceHost> _servicesHosts;

        public CustomServiceHostInitializer(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;

            _servicesHosts = new List<ServiceHost>();
        }

        public ServiceHost Initialize<TContract>()
        {
            ServiceHost serviceHost = CreateServiceHost<TContract>();
            serviceHost.AddDependencyInjectionBehavior<TContract>(_lifetimeScope);
            serviceHost.Open();
            _servicesHosts.Add(serviceHost);
            return serviceHost;
        }

        protected virtual ServiceHost CreateServiceHost<TContract>()
        {
            return new ServiceHost(GetImplemetnationType<TContract>());
        }

        private Type GetImplemetnationType<TContract>()
        {
            return _lifetimeScope.ComponentRegistry.Registrations
                .SelectMany(r => r.Services.OfType<IServiceWithType>(),
                    (r, s) => new { r.Activator.LimitType, s.ServiceType })
                .First(arg => arg.ServiceType == typeof(TContract))
                .LimitType;
        }

        public void Dispose()
        {
            foreach (ServiceHost serviceHost in _servicesHosts)
            {
                if (serviceHost == null)
                {
                    return;
                }

                if (serviceHost.State != CommunicationState.Faulted)
                {
                    serviceHost.Close();
                }
                else
                {
                    serviceHost.Abort();
                }
            }
        }
    }
}