using System;

public class PowerTest : ITestStep
{
    private readonly IInstrument _powerMeter;
    private readonly Limits _limits;

    public PowerTest(MockPowerMeter powerMeter, Limits limits)
    {
        _powerMeter = powerMeter;
        _limits = limits;
    }
    public string Name => "PowerTest";
    public bool IsCritical => true;
    public TestResult Test()
    {
        double measuredValue = _powerMeter.Measure();
        bool passed = (measuredValue >= _limits.MinPower) && (measuredValue <= _limits.MaxPower);
        return new TestResult
        {
            TestName = Name,
            MeasuredValue = measuredValue,
            Unit = "dBm",
            MinLimit = _limits.MinPower,
            MaxLimit = _limits.MaxPower,
            Status = passed ? "Passed" : "Failed",
            Time = DateTime.Now
        };
    }
}
