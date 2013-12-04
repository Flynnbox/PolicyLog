namespace PolicyLogDemo.Policy
{
	public class PolicyLogEntry
	{
		public string Policy { get; private set; }
		public PolicyResult Result { get; private set;}
		public string Details { get; private set; }

		public PolicyLogEntry(string policy, PolicyResult result, string details)
		{
			Policy = policy;
			Result = result;
			Details = details;
		}

		public PolicyLogEntry(string policy, PolicyResult result) : this(policy, result, string.Empty)
		{
		}

		public override string ToString()
		{
			return string.Format("Policy: {0}, Result: {1}, Details: {2}", Policy, Result, Details);
		}
	}
}