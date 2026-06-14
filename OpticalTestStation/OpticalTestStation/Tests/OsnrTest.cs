using System;

public class OsnrTest : ITestStep
{
    private readonly MockOSA _osa;
    private readonly Limits _limits;
    public OsnrTest(MockOSA osa , Limits limits) 
    {
        _osa = osa;
        _limits = limits;
    }
    public string Name => "Osnr Test";
    public bool IsCritical => false;
    public TestResult Test()
    {
        double measuredValue = _osa.MeasureOsnr();
        bool passed = measuredValue >= _limits.MinOsnr;

        return new TestResult
        {
            TestName = Name,
            MeasuredValue = measuredValue,
            Unit = "dB",
            MinLimit = _limits.MinOsnr,
            Status = passed? "Passed" : "Failed",
            Time = DateTime.Now,
        };
    }
}
