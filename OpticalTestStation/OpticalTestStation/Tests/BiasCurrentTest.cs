using System;

public class BiasCurrentTest : ITestStep
{
	private readonly IInstrument _tls;
	private readonly Limits _limits;
    public BiasCurrentTest(MockTLS tls, Limits limits)
	{
		_tls = tls;
		_limits = limits;
	}
	public string Name => "BiasCurrentTest";
	public bool IsCritical => true;
	public TestResult Test()
	{
		double measuredValue = _tls.Measure();
		bool passed = measuredValue <= _limits.MaxBiasCurrent;

        return new TestResult
		{
			TestName = Name,
			MeasuredValue = measuredValue,
			Unit = "mA",
			MaxLimit= _limits.MaxBiasCurrent,
			MinLimit= null,
            Status = passed ? "Passed" : "Failed",
            Time = DateTime.Now,
        };
	}
}
