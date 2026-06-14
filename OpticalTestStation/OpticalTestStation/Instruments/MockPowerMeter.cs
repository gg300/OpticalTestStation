using System;

public class MockPowerMeter : IInstrument
{
    public double Measure()
    {
        // Simulate a measurement by returning a random value
        Random rand = new Random();
        return rand.NextDouble() * -10;
    }
}
