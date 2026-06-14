using System;

public class WavelengthTest : ITestStep
{
	private readonly MockOSA _osa;
	private readonly Limits _limits;
    public WavelengthTest(MockOSA osa, Limits limits)
	{
		_osa = osa;
		_limits = limits;
	}
	public string Name => "Wave Length Test";
	public bool IsCritical => true;
	public TestResult Test()
	{
		double measuredValue = _osa.MeasureWaveLength();
		double minLimit = _limits.TargetWavelength - _limits.WavelengthTolerance;
		double maxLimit = _limits.TargetWavelength + _limits.WavelengthTolerance;
		bool passed = (measuredValue >= minLimit) && (measuredValue <= maxLimit);
		return new TestResult
		{
			TestName = Name,
			MeasuredValue = measuredValue,
			Unit = "nm",
			MaxLimit = maxLimit,
			MinLimit = minLimit,
			Status = passed?"Passed":"Failed",
			Time = DateTime.Now,

		};
	}

}
