using PolicyLogDemo.Example;

namespace PolicyLogDemo
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var policies = ExamplePolicyFactory.GetLastEvaluatedExamplePolicy();
			var log = policies.GetPolicyLog(null);
		}
	}
}