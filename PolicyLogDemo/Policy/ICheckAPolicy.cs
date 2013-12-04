namespace PolicyLogDemo.Policy
{
	public interface ICheckAPolicy
	{
		PolicyLog GetPolicyLog(object policyDataProvider);
	}
}