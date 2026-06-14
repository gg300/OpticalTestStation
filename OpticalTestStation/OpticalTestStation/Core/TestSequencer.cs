using System;

public class TestSequencer
{
	private readonly List<ITestStep> _steps;
	public TestSequencer(List <ITestStep> steps)
	{
		_steps = steps;
	}
	public List<TestResult> TestAll()
	{
		var results = new List<TestResult>();
		bool aborted = false;
		foreach(ITestStep step in _steps)
		{
			if (aborted)
			{
				results.Add(new TestResult
				{
					TestName = step.Name,
					Status = "SKIP"
				});
				continue;
			}
			var result = step.Test();
			results.Add(result);
			PrintResult(result);

			if (result.Status == "Failed" && step.IsCritical)
			{
				aborted = true;
			}
		}
		return results;
	}
	public void PrintResult(TestResult result) {
		string limits="";
		if (result.MinLimit.HasValue)
		{
			if(result.MaxLimit.HasValue) {
				limits = $"limits: {result.MinLimit} to {result.MaxLimit}";
            }
            else
			{
                limits = $"minLimit:  {result.MinLimit}";
            }
        }
		else
		{
			if (result.MaxLimit.HasValue){
				limits = $"maxLimit:  {result.MaxLimit}";
			}
        }
		Console.WriteLine($"[{result.Status}] {result.TestName} Measurement: {result.MeasuredValue} {limits} {result.Unit}");
    }
}
