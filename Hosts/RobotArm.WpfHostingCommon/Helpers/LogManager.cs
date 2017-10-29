using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotArm.WpfHostingCommon.Helpers
{
    public class LogManager
    {
        private const int LogsNumberExcess = 100;

        private List<string> _logs;

        public LogManager()
            : this(50)
        {
        }

        public LogManager(int maxLogs)
        {
            _logs = new List<string>();
            MaxLogs = maxLogs;
        }

        public List<string> Logs => _logs.Skip(Math.Max(0, _logs.Count - MaxLogs)).ToList();
        public string TextLogs => ConvertLogsToInfo();
        public int MaxLogs { get; set; }

        public void AddLog(string log)
        {
            if (_logs.Count >= MaxLogs + LogsNumberExcess)
            {
                _logs = _logs.Skip(Math.Max(0, _logs.Count - MaxLogs)).ToList();
            }

            _logs.Add(log);
        }

        private string ConvertLogsToInfo()
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < _logs.Count; i++)
            {
                builder.AppendLine($"{i}. {Logs[i]}");
            }

            return builder.ToString();
        }
    }
}