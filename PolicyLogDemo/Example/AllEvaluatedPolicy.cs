using System.Collections.Generic;
using PolicyLogDemo.Policy;

namespace PolicyLogDemo.Example
{
	/// <summary>
	///   Returns all evaluated policies it has evaluated, which will be every policy up to and including
	///   the first policy that triggered an interruption or the last policy in its list if no interruptions occured
	/// </summary>
	public class AllEvaluatedPolicy : PolicyHolder, ICheckAPolicy
	{
		public AllEvaluatedPolicy(IEnumerable<ICheckAPolicy> policies, IEnumerable<PolicyResult> interruptTriggers)
			: base(policies, interruptTriggers)
		{
		}

		public virtual PolicyLog GetPolicyLog(object policyDataProvider)
		{
			return new PolicyLog(GetAggregatePolicyLog(policyDataProvider).Log);
		}
	}
}