using System;

public class TestResult
{
    public string TestName { get; set; } = "";
    public double? MeasuredValue { get; set; }
    public string Unit { get; set; } = "";
    public double? MaxLimit { get; set; }
    public double? MinLimit { get; set; }
    public string Status { get; set; } = "";
    public DateTime Time { get; set; } = DateTime.Now;
}
