using System;

public class TestConfig
{
	public string ProductId { get; set; } = "";
	public Limits Limits = new Limits();
}
public class Limits
{
	public double MinPower { get; set; }
	public double MaxPower { get; set; }
	public double TargetWavelength { get; set; }
	public double WavelengthTolerance { get; set; }
	public double MinOsnr { get; set; }
	public double MaxBiasCurrent { get; set; }

}
