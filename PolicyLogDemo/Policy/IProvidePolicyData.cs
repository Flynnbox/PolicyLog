using System.Collections;

namespace PolicyLogDemo.Policy
{
	public interface IProvidePolicyData
	{
		IDictionary GetPolicyData();
	}
}