using System;

public class MockTLS : IInstrument //tunable laser source
{
    public double Measure()
    {
        // Simulate a measurement by returning a random value
        Random rand = new Random();
        return rand.NextDouble();
    }
}
