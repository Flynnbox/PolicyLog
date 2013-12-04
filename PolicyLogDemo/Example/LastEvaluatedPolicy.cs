using System.Collections.Generic;
using System.Linq;
using PolicyLogDemo.Policy;

namespace PolicyLogDemo.Example
{
	/// <summary>
	/// Returns the last evaluated policy it has evaluated, which will be either 
	/// the first policy that triggered an interruption or the last policy in its list if no interruptions occured
	/// </summary>
	public class LastEvaluatedPolicy : PolicyHolder, ICheckAPolicy
	{
		public LastEvaluatedPolicy(IEnumerable<ICheckAPolicy> policies, IEnumerable<PolicyResult> interruptTriggers)
			: base(policies, interruptTriggers)
		{
		}

		#region ICheckAPolicy Members

		public virtual PolicyLog GetPolicyLog(object policyDataProvider)
		{
			return new PolicyLog(GetAggregatePolicyLog(policyDataProvider).Log.Last());
		}

		#endregion
	}
}