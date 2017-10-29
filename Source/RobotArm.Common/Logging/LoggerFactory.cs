using System.Collections.Generic;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Filter;
using log4net.Layout;
using log4net.Repository;

namespace RobotArm.Common.Logging
{
    public static class LoggerFactory
    {
        private static readonly Dictionary<ELogger, ILog> Loggers = new Dictionary<ELogger, ILog>
        {
            { ELogger.Common, CreateCommonLogger() },
            { ELogger.UserManagement, CreateUserManagementLogger() }
        };

        public static ILog GetLogger(ELogger logger)
        {
            return Loggers[logger];
        }

        // TODO: Move configurarion to *.config file 
        private static ILog CreateCommonLogger()
        {
            string instanceName = "Common";

            PatternLayout layout = new PatternLayout(
                "% date{ MMM / dd / yyyy HH:mm: ss,fff}[%thread] %-5level %logger %ndc – %message%newline");

            LevelMatchFilter filter = new LevelMatchFilter();
            filter.LevelToMatch = Level.All;
            filter.ActivateOptions();

            RollingFileAppender appender = new RollingFileAppender();
            appender.File = "common.log"; // string.Format("{0}\\{1}", "", "common.log");
            appender.ImmediateFlush = true;
            appender.AppendToFile = true;
            appender.RollingStyle = RollingFileAppender.RollingMode.Date;
            appender.DatePattern = "-yyyy - MM - dd";
            appender.LockingModel = new FileAppender.MinimalLock();
            appender.Name = string.Format("{0}Appender", instanceName);
            appender.AddFilter(filter);
            appender.Layout = layout;
            appender.ActivateOptions();

            string repositoryName = string.Format("{0}Repository", instanceName);
            ILoggerRepository repository = LoggerManager.CreateRepository(repositoryName);
            string loggerName = string.Format("{0}Logger", instanceName);
            BasicConfigurator.Configure(repository, appender);
            return LogManager.GetLogger(repositoryName, loggerName);
        }

        private static ILog CreateUserManagementLogger()
        {
            string instanceName = "UserManagement";

            PatternLayout layout = new PatternLayout(
                "% date{ MMM / dd / yyyy HH:mm: ss,fff}[%thread] %-5level %logger %ndc – %message%newline");

            LevelMatchFilter filter = new LevelMatchFilter();
            filter.LevelToMatch = Level.All;
            filter.ActivateOptions();

            RollingFileAppender appender = new RollingFileAppender();
            appender.File = "userManagement.log"; // string.Format("{0}\\{1}", "", "common.log");
            appender.ImmediateFlush = true;
            appender.AppendToFile = true;
            appender.RollingStyle = RollingFileAppender.RollingMode.Date;
            appender.DatePattern = "-yyyy - MM - dd";
            appender.LockingModel = new FileAppender.MinimalLock();
            appender.Name = string.Format("{0}Appender", instanceName);
            appender.AddFilter(filter);
            appender.Layout = layout;
            appender.ActivateOptions();

            string repositoryName = string.Format("{0}Repository", instanceName);
            ILoggerRepository repository = LoggerManager.CreateRepository(repositoryName);
            string loggerName = string.Format("{0}Logger", instanceName);
            BasicConfigurator.Configure(repository, appender);
            return LogManager.GetLogger(repositoryName, loggerName);
        }
    }
}