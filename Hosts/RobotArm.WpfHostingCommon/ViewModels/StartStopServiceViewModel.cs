using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using System.Windows.Input;
using RobotArm.HostingCommon;
using RobotArm.HostingCommon.Initializing;
using RobotArm.WpfHostingCommon.Commands;
using RobotArm.WpfHostingCommon.Helpers;

namespace RobotArm.WpfHostingCommon.ViewModels
{
    public class StartStopServiceViewModel : BaseViewModel
    {
        private IServiceHostInitializer _serviceHostInitializer;

        private readonly Type[] _services;
        private Dictionary<Type, ServiceHost> _servicesHosts;

        private readonly LogManager _logManager;

        public StartStopServiceViewModel(IServiceHostInitializer serviceHostInitializer, params Type[] services)
        {
            _serviceHostInitializer = serviceHostInitializer;
            _services = services;

            _logManager = new LogManager();

            StartServiceCommand = new ParameterlessRelayCommand(StartService);
            StopServiceCommand = new ParameterlessRelayCommand(StopService);

            StartEnable = true;
            StopEnable = false;
        }

        public ICommand StartServiceCommand { get; private set; }
        public ICommand StopServiceCommand { get; private set; }

        public bool StartEnable { get; private set; }
        public bool StopEnable { get; private set; }
        public string Info => _logManager.TextLogs;

        private void StartService()
        {
            StartEnable = false;

            _servicesHosts = new Dictionary<Type, ServiceHost>();
            try
            {
                foreach (var serviceType in _services)
                {
                    var serviceHost = this.InitializeService(serviceType);
                    _servicesHosts.Add(serviceType, serviceHost);
                    
                    _logManager.AddLog($"Service: {serviceType.Name} started successfully");
                }

                StopEnable = true;
            }
            catch (Exception e)
            {
                _logManager.AddLog($"ERROR: Failed: {e.Message}");
                StartEnable = true;
            }

            this.OnPropertyChanged($"Info");
        }

        private void StopService()
        {
            StopEnable = false;

            foreach (var serviceHost in _servicesHosts.Values)
            {
                if (serviceHost != null)
                {
                    try
                    {
                        serviceHost.Close();

                        _logManager.AddLog("Service stoped successfully");
                    }
                    catch (Exception e)
                    {
                        _logManager.AddLog($"ERROR: Failed: {e.Message}");
                    }
                }
            }

            this.OnPropertyChanged($"Info");

            StartEnable = true;
        }

        private ServiceHost InitializeService(Type serviceType)
        {
            return (ServiceHost)CreateInitializeServiceMethod(serviceType).Invoke(_serviceHostInitializer, null);
        }

        private MethodInfo CreateInitializeServiceMethod(Type serviceType)
        {
            MethodInfo createServiceMethod = _serviceHostInitializer.GetType().GetMethod("Initialize");

            if (createServiceMethod == null)
            {
                throw new Exception("Initialize method does not exist in service host initializer");
            }

            return createServiceMethod.MakeGenericMethod(serviceType);
        }
    }
}