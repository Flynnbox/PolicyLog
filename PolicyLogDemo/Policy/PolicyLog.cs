using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PolicyLogDemo.Policy
{
	public class PolicyLog
	{
		private readonly List<PolicyLogEntry> log = new List<PolicyLogEntry>();

		public PolicyLog()
		{
		}

		public PolicyLog(PolicyLogEntry logEntry)
		{
			Append(logEntry);
		}

    public PolicyLog(IEnumerable<PolicyLogEntry> logEntries)
    {
      Append(logEntries);
    }

		public ReadOnlyCollection<PolicyLogEntry> Log
		{
			get { return log.AsReadOnly(); }
		}

		public bool AllEntriesMatchResult(PolicyResult result)
		{
			return log.TrueForAll(logEntry => logEntry.Result.Equals(result));
		}

		public bool ContainsEntryMatchingResult(PolicyResult result)
		{
			return log.Exists(logEntry => logEntry.Result.Equals(result));
		}

		public List<PolicyLogEntry> GetEntriesMatchingResult(PolicyResult result)
		{
			return log.FindAll(logEntry => logEntry.Result.Equals(result));
		}

		public void Append(IEnumerable<PolicyLogEntry> logEntries)
		{
			log.AddRange(logEntries);
		}

		public void Append(PolicyLogEntry logEntry)
		{
			log.Add(logEntry);
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("; ");
			foreach(PolicyLogEntry logEntry in log)
			{
				sb.Append(logEntry.ToString());
			}
			return (sb.Length > 2) ? sb.ToString().Substring(2) : String.Empty;
		}
	}
}