using System;
using PolicyLogDemo.Policy;

namespace PolicyLogDemo.Example
{
	public class IsCurrentMinuteEventNumberPolicy : ICheckAPolicy
	{
		public const string NAME = "IsCurrentMinuteEventNumberPolicy";

		public PolicyLog GetPolicyLog(object policyDataProvider)
		{
			PolicyLog log = new PolicyLog();
			try
			{
				var result = DateTime.Now.Minute % 2 == 0;


				log.Append(new PolicyLogEntry(NAME, result ? PolicyResult.Success : PolicyResult.Failure));
			}
			catch (Exception ex){
				log.Append(new PolicyLogEntry(NAME, PolicyResult.Unresolved, ex.ToString()));
			}
			return log;
		}
	}
}
