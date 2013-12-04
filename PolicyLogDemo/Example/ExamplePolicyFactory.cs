using PolicyLogDemo.Policy;

namespace PolicyLogDemo.Example
{
	public class ExamplePolicyFactory
	{
		public static ICheckAPolicy GetLastEvaluatedExamplePolicy()
		{
			PolicyResult[] interruptTriggers = new[]{PolicyResult.Success, PolicyResult.Unresolved};

			ICheckAPolicy[] policies = new ICheckAPolicy[]{
  			new IsCurrentMinuteEventNumberPolicy(),
			};

			return new LastEvaluatedPolicy(policies, interruptTriggers);
		}

    public static ICheckAPolicy GetAllEvaluatedExamplePolicy()
    {
      PolicyResult[] interruptTriggers = new[] { PolicyResult.Success, PolicyResult.Unresolved };

      ICheckAPolicy[] policies = new ICheckAPolicy[]{
  			new IsCurrentMinuteEventNumberPolicy(),

			};

      return new AllEvaluatedPolicy(policies, interruptTriggers);
    }
	}
}