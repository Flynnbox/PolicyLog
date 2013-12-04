using System.Collections.Generic;
using System.Reflection;

namespace PolicyLogDemo.Policy
{
	public class PolicyHolder
	{
		/// <summary>
		/// Returns a list of Policies held
		/// </summary>
		public List<ICheckAPolicy> Policies { get; private set; }

		/// <summary>
		/// Returns a list of PolicyResults that will eagerly exit policy evaluation
		/// </summary>
		public List<PolicyResult> PolicyEvaluationInterrupts { get; private set; }

		//private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		public PolicyHolder(IEnumerable<ICheckAPolicy> policies, IEnumerable<PolicyResult> interruptTriggers)
		{
			Policies = new List<ICheckAPolicy>();
			if (policies != null)
			{
				Policies.AddRange(policies);
			}

			PolicyEvaluationInterrupts = new List<PolicyResult>();
			if (interruptTriggers != null)
			{
				PolicyEvaluationInterrupts.AddRange(interruptTriggers);
			}
		}

		public PolicyHolder(ICheckAPolicy policy, IEnumerable<PolicyResult> interruptTriggers) : this(new[]{policy}, interruptTriggers)
		{
		}

		public PolicyHolder(ICheckAPolicy policy, PolicyResult interruptTrigger) : this (new[]{policy}, new[]{interruptTrigger})
		{
		}

		public PolicyHolder(ICheckAPolicy policy) : this(new[]{policy}, null)
		{
		}

		public PolicyHolder() : this(new ICheckAPolicy[0], new PolicyResult[0])
		{
		}

		/// <summary>
		/// Iterates through all contained policies, evaluates them, and return an appended log of their results.
		/// If an interruption trigger result is encountered, the log containing the interruption is appended and evaluation exits
		/// </summary>
		/// <param name="policyDataProvider"></param>
		public virtual PolicyLog GetAggregatePolicyLog(object policyDataProvider)
		{
			PolicyLog aggregatePolicyLog = new PolicyLog();

			foreach (ICheckAPolicy policy in Policies)
			{
				PolicyLog policyLog = policy.GetPolicyLog(policyDataProvider);

				//if(log.IsDebugEnabled)
				//{
				//	log.DebugFormat(policyLog.ToString());
				//}

				aggregatePolicyLog.Append(policyLog.Log);
				if (IsEvaluationInterrupted(policyLog))
				{
					return aggregatePolicyLog;
				}
			}
			return aggregatePolicyLog;
		}

		private bool IsEvaluationInterrupted(PolicyLog log)
		{
			return PolicyEvaluationInterrupts.Count > 0 && PolicyEvaluationInterrupts.Exists(log.ContainsEntryMatchingResult);
		}
	}
}