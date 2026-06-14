using System;

public interface ITestStep
{
    public string Name { get;}
    bool IsCritical { get;}
    TestResult Test();

}
