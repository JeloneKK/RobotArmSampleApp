using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RobotArm.Common.Logging.Helpers
{
    public static class LogHelper
    {
        public static string GetMethodInfoErrorMessage(MethodBase method, params object[] parameters)
        {
            StringBuilder builder = new StringBuilder("Error occured in ");

            if (method == null)
            {
                builder.Append("unknow method");

                return builder.ToString();
            }

            builder.Append($"method: {method.Name} ");

            ParameterInfo[] parameterInfos = method.GetParameters();

            if (!parameterInfos.Any() || parameterInfos.Length != parameters.Length)
            {
                return builder.ToString();
            }

            builder.Append("called with parameters: ");

            for (int i = 0; i < parameterInfos.Length; i++)
            {
                builder.Append($"{parameterInfos[i].Name}: {parameters[i]} ");
            }

            return builder.ToString();
        }
    }
}