using System;

public class MockOSA : IInstrument //optical signal analyzer
{
    public double Measure()
    {
        // Simulate a measurement by returning a random value
        Random rand = new Random();
        return rand.NextDouble();
    }
    public double MeasureWaveLength()
    {
        
        Random rand = new Random();
        return 1549.8 + rand.NextDouble() * 0.4;
    }
    public double MeasureOsnr()
    {
        
        Random rand = new Random();
        return rand.NextDouble() * 100;
    }
}
